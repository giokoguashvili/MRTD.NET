using System;
using System.Collections.Generic;
using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.View;

namespace SmartCardApi.DataGroups
{
    public class DGDataView
    {
        private readonly IBerTLV[] _berTLVTree;
        private readonly Dictionary<string, string> _dgTags = new Dictionary<string, string>()
        {
            { "60", "EF.COM" },
            { "61", "DG1" },
            { "75", "DG2" },
            { "63", "DG3" },
            { "76", "DG4" },
            { "65", "DG5" },
            { "66", "DG6" },
            { "67", "DG7" },
            { "68", "DG8" },
            { "69", "DG9" },
            { "6A", "DG10" },
            { "6B", "DG11" },
            { "6C", "DG12" },
            { "6D", "DG13" },
            { "6E", "DG14" },
            { "6F", "DG15" },
            { "70", "DG16" },
            { "77", "EF.SOD" },
        };
        public DGDataView(IBinary dgData)
        {
            _berTLVTree = new IBerTLV[] { new BerTLV(dgData) };
        }

        public void View()
        {
            Console.WriteLine("\n{0}:", _dgTags[_berTLVTree.First().T]);
            new BerTLVView(_berTLVTree).View();
        }
    }
} 