using blog03.HotNews;
using blog03.HotNews.Repositories;
using blog03.ToolKits.Extensions;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03.BackgroundJobs.Jobs.HotNews
{
    public class HostNewsJob : IBackgroundJob
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHotNewsRepository _hotNewsRepository;
        private readonly ILogger<HostNewsJob> _logger;

        public HostNewsJob(IHttpClientFactory httpClientFactory, IHotNewsRepository hotNewsRepository, ILogger<HostNewsJob> logger)
        {
            _httpClientFactory = httpClientFactory;
            _hotNewsRepository = hotNewsRepository;
            _logger = logger;
        }

        public async Task ExecuteAsync()
        {
            var hotnewsUrls = new List<HotNewsJobItem<string>>
            {
                new HotNewsJobItem<string> { Result = "https://www.cnblogs.com", Source = HotNewsEnum.cnblogs },
                new HotNewsJobItem<string> { Result = "https://www.v2ex.com/?tab=hot", Source = HotNewsEnum.v2ex },
                new HotNewsJobItem<string> { Result = "https://segmentfault.com/hottest", Source = HotNewsEnum.segmentfault },
                new HotNewsJobItem<string> { Result = "https://web-api.juejin.im/query", Source = HotNewsEnum.juejin },
                new HotNewsJobItem<string> { Result = "https://weixin.sogou.com", Source = HotNewsEnum.weixin },
                new HotNewsJobItem<string> { Result = "https://www.douban.com/group/explore", Source = HotNewsEnum.douban },
                new HotNewsJobItem<string> { Result = "https://www.ithome.com", Source = HotNewsEnum.ithome },
                new HotNewsJobItem<string> { Result = "https://36kr.com/newsflashes", Source = HotNewsEnum.kr36 },
                new HotNewsJobItem<string> { Result = "http://tieba.baidu.com/hottopic/browse/topicList", Source = HotNewsEnum.tieba },
                new HotNewsJobItem<string> { Result = "http://top.baidu.com/buzz?b=341", Source = HotNewsEnum.baidu },
                new HotNewsJobItem<string> { Result = "https://s.weibo.com/top/summary/summary", Source = HotNewsEnum.weibo },
                new HotNewsJobItem<string> { Result = "https://www.zhihu.com/api/v3/feed/topstory/hot-lists/total?limit=50&desktop=true", Source = HotNewsEnum.zhihu },
                new HotNewsJobItem<string> { Result = "https://daily.zhihu.com", Source = HotNewsEnum.zhihudaily },
                new HotNewsJobItem<string> { Result = "http://news.163.com/special/0001386F/rank_whole.html", Source = HotNewsEnum.news163 },
                new HotNewsJobItem<string> { Result = "https://github.com/trending", Source = HotNewsEnum.github },
                new HotNewsJobItem<string> { Result = "https://www.iesdouyin.com/web/api/v2/hotsearch/billboard/word", Source = HotNewsEnum.douyin_hot },
                new HotNewsJobItem<string> { Result = "https://www.iesdouyin.com/web/api/v2/hotsearch/billboard/aweme", Source = HotNewsEnum.douyin_video },
                new HotNewsJobItem<string> { Result = "https://www.iesdouyin.com/web/api/v2/hotsearch/billboard/aweme/?type=positive", Source = HotNewsEnum.douyin_positive },
            };
            var web = new HtmlWeb();
            var list_task = new List<Task<HotNewsJobItem<object>>>();
            hotnewsUrls.ForEach(async item =>
            {
                var task = Task.Run(async () =>
                  {
                      var obj = new Object();
                      if (item.Source == HotNewsEnum.juejin)
                      {
                          using var client = _httpClientFactory.CreateClient();
                          client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.14 Safari/537.36 Edg/83.0.478.13");
                          client.DefaultRequestHeaders.Add("X-Agent", "Juejin/Web");
                          var data = "{\"extensions\":{\"query\":{ \"id\":\"21207e9ddb1de777adeaca7a2fb38030\"}},\"operationName\":\"\",\"query\":\"\",\"variables\":{ \"first\":20,\"after\":\"\",\"order\":\"THREE_DAYS_HOTTEST\"}}";
                          var buffer = data.SerializeUtf8();
                          var byteContent = new ByteArrayContent(buffer);
                          byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                          var httpResponse = await client.PostAsync(item.Result, byteContent);
                          obj = await httpResponse.Content.ReadAsStringAsync();
                      }
                      else
                      {
                          Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                          obj = await web.LoadFromWebAsync(item.Result, (item.Source == HotNewsEnum.baidu || item.Source == HotNewsEnum.news163) ? Encoding.GetEncoding("GB2312") : Encoding.UTF8);
                      }
                      return new HotNewsJobItem<object>
                      {
                          Result = obj,
                          Source = item.Source,
                      };
                  });
                list_task.Add(task);
            });
            Task.WaitAll(list_task.ToArray());

            var hotNews = new List<blog03.HotNews.HotNews>();
            foreach (var list in list_task)
            {
                var item = await list;
                var sourceId = (int)item.Source;
                if (item.Source == HotNewsEnum.cnblogs)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//div[@class='post_item_body']/h3/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.InnerText,
                            Url=x.GetAttributeValue("href",""),
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.v2ex)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//span[@class='item_title']/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.InnerText,
                            Url=$"https://www.v2ex.com{x.GetAttributeValue("href","")}",
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.segmentfault)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//div[@class='news__item-info clearfix']/a").Where(x=>x.InnerText.IsNotNullOrEmpty()).ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.SelectSingleNode(".//h4").InnerText,
                            Url=$"https://segmentfault.com{x.GetAttributeValue("href","")}",
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.juejin)
                {
                    var obj = JObject.Parse((string)item.Result);
                    var nodes = obj["data"]["articleFeed"]["items"]["edges"];
                    foreach(var node in nodes)
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=node["node"]["title"].ToString(),
                            Url=node["node"]["originalUrl"].ToString(),
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    }
                }
                if (item.Source == HotNewsEnum.weixin)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//ul[@class='news-list']/li/div[@class='txt-box']/h3/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.InnerText,
                            Url=x.GetAttributeValue("href",""),
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.douban)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//div[@class='channel-item']/div[@class='bd']/h3/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.InnerText,
                            Url=x.GetAttributeValue("href",""),
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.kr36)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//div[@class='hotlist-main']/div[@class='hotlist-item-toptwo']/a[2]|//div[@class='hot-main']/div[@class='hotlist-item-other clearfloat']/div[@class='hotlist-item-other-info']/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.InnerText,
                            Url=$"https://36kr.com{x.GetAttributeValue("href","")}",
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.tieba)
                {
                    var obj = JObject.Parse(((HtmlDocument)item.Result).ParsedText);
                    var nodes = obj["data"]["bang_topic"]["topic_list"];
                    foreach(var node in nodes)
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=node["topic_name"].ToString(),
                            Url=node["topic_url"].ToString().Replace("amp;",""),
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    }
                }
                if (item.Source == HotNewsEnum.baidu)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//table[@class='list-table']//tr/td[@class='keyword']/a[@class='list-title']").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title=x.InnerText,
                            Url=x.GetAttributeValue("href",""),
                            SourceId=sourceId,
                            CreateTime=DateTime.Now,
                        });
                    });
                }
                if (item.Source == HotNewsEnum.weibo)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//table/tbody/tr/td[2]/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = x.InnerText,
                            Url = $"https://s.weibo.com{x.GetAttributeValue("href", "").Replace("#", "%23")}",
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    });
                }
                if (item.Source == HotNewsEnum.zhihu)
                {
                    var obj = JObject.Parse(((HtmlDocument)item.Result).ParsedText);
                    var nodes = obj["data"];
                    foreach (var node in nodes)
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = node["target"]["title"].ToString(),
                            Url = $"https://www.zhihu.com/question/{node["target"]["id"]}",
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    }
                }
                if (item.Source == HotNewsEnum.zhihudaily)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//div[@class='box']/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = x.InnerText,
                            Url = $"https://daily.zhihu.com{x.GetAttributeValue("href", "")}",
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    });
                }
                if (item.Source == HotNewsEnum.news163)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//div[@class='area-half left']/div[@class='tabBox']/div[@class='tabContents active']/table//tr/td[1]/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = x.InnerText,
                            Url = x.GetAttributeValue("href", ""),
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    });
                }
                if (item.Source == HotNewsEnum.github)
                {
                    var nodes = ((HtmlDocument)item.Result).DocumentNode.SelectNodes("//article[@class='Box-row']/h1/a").ToList();
                    nodes.ForEach(x =>
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = x.InnerText.Trim().Replace("\n", "").Replace(" ", ""),
                            Url = $"https://github.com{x.GetAttributeValue("href", "")}",
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    });
                }
                if (item.Source == HotNewsEnum.douyin_hot)
                {
                    var obj = JObject.Parse(((HtmlDocument)item.Result).ParsedText);
                    var nodes = obj["word_list"];
                    foreach (var node in nodes)
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = node["word"].ToString(),
                            Url = $"#{node["hot_value"]}",
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    }
                }
                if (item.Source == HotNewsEnum.douyin_video || item.Source == HotNewsEnum.douyin_positive)
                {
                    var obj = JObject.Parse(((HtmlDocument)item.Result).ParsedText);
                    var nodes = obj["aweme_list"];
                    foreach (var node in nodes)
                    {
                        hotNews.Add(new blog03.HotNews.HotNews
                        {
                            Title = node["aweme_info"]["desc"].ToString(),
                            Url = node["aweme_info"]["share_url"].ToString(),
                            SourceId = sourceId,
                            CreateTime = DateTime.Now
                        });
                    }
                }
            }
            if (hotNews.Any())
            {
                await _hotNewsRepository.DeleteAsync(x => true);
                await _hotNewsRepository.BulkInsertAsync(hotNews);
            }
            _logger.LogInformation($"【定时任务】每日热点数据抓取({hotNews.Count})");
        }
    }
}
