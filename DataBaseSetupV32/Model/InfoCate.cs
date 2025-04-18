﻿using System;
using System.Collections.Generic;

namespace DataBaseSetupV3.Model
{
    public partial class InfoCate
    {
        public string InfoCateId { get; set; }
        public string MainComId { get; set; }
        public string PrarentsId { get; set; }
        public string InfoCateName { get; set; }
        public int Levels { get; set; }
        public string OperatedUserName { get; set; }
        public DateTime OperatedDate { get; set; }
        public string LanguageCode { get; set; }
    }
}
