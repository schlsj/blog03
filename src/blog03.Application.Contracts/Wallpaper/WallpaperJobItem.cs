using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03.Wallpaper
{
    public class WallpaperJobItem<T>
    {
        public T Result { get; set; }
        public WallpaperEnum Type { get; set; }
    }
}
