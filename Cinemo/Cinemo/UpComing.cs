using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemo
{
    class UpComing
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public string MovieLanguage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string RatedPGI { get; set; }
        public string MovieType { get; set; }
        public object TrailorLink { get; set; }
        public string Logo { get; set; }
        public object LogoFile { get; set; }
    }
}