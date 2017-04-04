﻿using SmartCardApi.DataGroups.Content;
using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.DataGroups
{
    public class DG11 : IDataGroup<DGContent>
    {
        private readonly IBacReader _bacReader;
        private readonly IBinary _fid = new BinaryHex("010B");
        public DG11(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }
        public byte[] Bytes()
        {
            return _bacReader.DGData(_fid).Bytes();
        }

        public DGContent Content()
        {
            return new DGContent(); //_bacReader.DGData(_fid)
        }
    }
}