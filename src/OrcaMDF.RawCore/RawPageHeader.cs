﻿using OrcaMDF.Framework;
using System;

namespace OrcaMDF.RawCore
{
	public class RawPageHeader
	{
		private readonly RawDatabase db;
		private readonly RawPage page;

		public ArraySegment<byte> RawBytes
		{
			get { return new ArraySegment<byte>(db.Data[page.FileID], page.DataFileIndex, 96); }
		}

		public short FreeCnt
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 28); }
		}

		public short FreeData
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 30); }
		}

		public ushort FlagBits
		{
			get { return BitConverter.ToUInt16(db.Data[page.FileID], page.DataFileIndex + 4); }
		}

		public string Lsn
		{
			get { return "(" + BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 40) + ":" + BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 44) + ":" + BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 48) + ")"; }
		}

		public int ObjectID
		{
			get { return BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 24); }
		}

		public PageType Type
		{
			get { return (PageType)db.Data[page.FileID][page.DataFileIndex + 1]; }
		}

		public short Pminlen
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 14); }
		}

		public short IndexID
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 6); }
		}

		public byte TypeFlagBits
		{
			get { return db.Data[page.FileID][page.DataFileIndex + 2]; }
		}

		public short SlotCnt
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 22); }
		}

		public string XdesID
		{
			get { return "(" + BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 56) + ":" + BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 52) + ")"; }
		}

		public short XactReserved
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 50); }
		}

		public short ReservedCnt
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 38); }
		}

		public byte Level
		{
			get { return db.Data[page.FileID][page.DataFileIndex + 3]; }
		}

		public byte HeaderVersion
		{
			get { return db.Data[page.FileID][page.DataFileIndex + 0]; }
		}

		public short GhostRecCnt
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 58); }
		}

		public short NextPageFileID
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 20); }
		}

		public int NextPageID
		{
			get { return BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 16); }
		}

		public short PreviousPageFileID
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 12); }
		}

		public int PreviousPageID
		{
			get { return BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 8); }
		}

		public int PageID
		{
			get { return BitConverter.ToInt32(db.Data[page.FileID], page.DataFileIndex + 32); }
		}

		public short FileID
		{
			get { return BitConverter.ToInt16(db.Data[page.FileID], page.DataFileIndex + 36); }
		}

		public ArraySegment<byte> Checksum
		{
			get { return new ArraySegment<byte>(db.Data[page.FileID], page.DataFileIndex + 60, 4); }
		}

		public RawPageHeader(RawPage page, RawDatabase db)
		{
			this.db = db;
			this.page = page;
		}
	}
}