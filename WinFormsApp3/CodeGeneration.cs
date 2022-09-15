
/*
Copyright (C) 2019-2022 TARAKHOMYN YURIY IVANOVYCH
All rights reserved.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

/*
Автор:    Тарахомин Юрій Іванович
Адреса:   Україна, м. Львів
Сайт:     accounting.org.ua
*/

/*
 *
 * Конфігурації "Нова конфігурація"
 * Автор 
  
 * Дата конфігурації: 15.09.2022 22:22:37
 *
 */

using System;
using System.Collections.Generic;
using AccountingSoftware;
using WinFormsApp3;

namespace WinFormsApp3
{
    public static class Config
    {
        public static Kernel Kernel { get; set; }
        public static Kernel KernelBackgroundTask { get; set; }
        public static Kernel KernelParalelWork { get; set; }

        public static void ReadAllConstants()
        {
            Константи.Основний.ReadAll();

        }
    }
}

namespace НоваКонфігурація_1_0.Константи
{

    #region CONSTANTS BLOCK "Основний"
    public static class Основний
    {
        public static void ReadAll()
        {

            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a2" }, fieldValue);

            if (IsSelect)
            {
                m_Тест_Const = fieldValue["col_a2"].ToString();

            }

        }


        static string m_Тест_Const = "";
        public static string Тест_Const
        {
            get
            {
                return m_Тест_Const;
            }
            set
            {
                m_Тест_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a2", m_Тест_Const);
            }
        }

    }
    #endregion

}

namespace НоваКонфігурація_1_0.Довідники
{

    #region DIRECTORY "Номенклатура"

    public static class Номенклатура_Const
    {
        public const string TABLE = "tab_a01";

        public const string Назва = "col_a1";
        public const string Код = "col_a2";
        public const string Виробник = "col_a3";
        public const string Тип = "col_a4";
        public const string код2 = "col_a5";
    }


    public class Номенклатура_Objest : DirectoryObject
    {
        public Номенклатура_Objest() : base(Config.Kernel, "tab_a01",
             new string[] { "col_a1", "col_a2", "col_a3", "col_a4", "col_a5" })
        {
            Назва = "";
            Код = "";
            Виробник = new Виробники_Pointer();
            Тип = 0;
            код2 = "";

            //Табличні частини
            Товари_TablePart = new Номенклатура_Товари_TablePart(this);

        }

        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = FieldValue["col_a1"].ToString();
                Код = FieldValue["col_a2"].ToString();
                Виробник = new Виробники_Pointer(FieldValue["col_a3"]);
                Тип = FieldValue["col_a4"] != DBNull.Value ? (Перелічення.ТипНоменклатури)FieldValue["col_a4"] : 0;
                код2 = FieldValue["col_a5"].ToString();

                BaseClear();
                return true;
            }
            else
                return false;
        }

        public void Save()
        {
            FieldValue["col_a1"] = Назва;
            FieldValue["col_a2"] = Код;
            FieldValue["col_a3"] = Виробник.UnigueID.UGuid;
            FieldValue["col_a4"] = (int)Тип;
            FieldValue["col_a5"] = код2;

            BaseSave();

        }

        public Номенклатура_Objest Copy()
        {
            Номенклатура_Objest copy = new Номенклатура_Objest();
            copy.New();
            copy.Назва = Назва;
            copy.Код = Код;
            copy.Виробник = Виробник;
            copy.Тип = Тип;
            copy.код2 = код2;

            return copy;
        }

        public void Delete()
        {

            BaseDelete(new string[] { "tab_a02" });
        }

        public Номенклатура_Pointer GetDirectoryPointer()
        {
            Номенклатура_Pointer directoryPointer = new Номенклатура_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }

        public string Назва { get; set; }
        public string Код { get; set; }
        public Виробники_Pointer Виробник { get; set; }
        public Перелічення.ТипНоменклатури Тип { get; set; }
        public string код2 { get; set; }

        //Табличні частини
        public Номенклатура_Товари_TablePart Товари_TablePart { get; set; }

    }


    public class Номенклатура_Pointer : DirectoryPointer
    {
        public Номенклатура_Pointer(object uid = null) : base(Config.Kernel, "tab_a01")
        {
            Init(new UnigueID(uid), null);
        }

        public Номенклатура_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a01")
        {
            Init(uid, fields);
        }

        public Номенклатура_Objest GetDirectoryObject()
        {
            if (IsEmpty()) return null;
            Номенклатура_Objest НоменклатураObjestItem = new Номенклатура_Objest();
            return НоменклатураObjestItem.Read(UnigueID) ? НоменклатураObjestItem : null;
        }

        public Номенклатура_Pointer GetNewDirectoryPointer()
        {
            return new Номенклатура_Pointer(UnigueID);
        }

        public string GetPresentation()
        {
            return BasePresentation(
                new string[] { "col_a1" }
            );
        }

        public Номенклатура_Pointer GetEmptyPointer()
        {
            return new Номенклатура_Pointer();
        }
    }


    public class Номенклатура_Select : DirectorySelect
    {
        public Номенклатура_Select() : base(Config.Kernel, "tab_a01") { }
        public bool Select() { return BaseSelect(); }

        public bool SelectSingle() { if (BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }

        public bool MoveNext() { if (MoveToPosition()) { Current = new Номенклатура_Pointer(DirectoryPointerPosition.UnigueID, DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Номенклатура_Pointer Current { get; private set; }

        public Номенклатура_Pointer FindByField(string name, object value)
        {
            Номенклатура_Pointer itemPointer = new Номенклатура_Pointer();
            DirectoryPointer directoryPointer = BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }

        public List<Номенклатура_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Номенклатура_Pointer> directoryPointerList = new List<Номенклатура_Pointer>();
            foreach (DirectoryPointer directoryPointer in BaseFindListByField(name, value, limit, offset))
                directoryPointerList.Add(new Номенклатура_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }


    public class Номенклатура_Товари_TablePart : DirectoryTablePart
    {
        public Номенклатура_Товари_TablePart(Номенклатура_Objest owner) : base(Config.Kernel, "tab_a02",
             new string[] { "col_a3", "col_a7", "col_a4", "col_a5", "col_a6" })
        {
            if (owner == null) throw new Exception("owner null");

            Owner = owner;
            Records = new List<Record>();
        }

        public Номенклатура_Objest Owner { get; private set; }

        public List<Record> Records { get; set; }

        public void Read()
        {
            Records.Clear();
            BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in FieldValueList)
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];

                record.НомерРядка = fieldValue["col_a3"] != DBNull.Value ? (int)fieldValue["col_a3"] : 0;
                record.НазваТовару = fieldValue["col_a7"].ToString();
                record.Кількість = fieldValue["col_a4"] != DBNull.Value ? (int)fieldValue["col_a4"] : 0;
                record.Ціна = fieldValue["col_a5"] != DBNull.Value ? (decimal)fieldValue["col_a5"] : 0;
                record.Сума = fieldValue["col_a6"] != DBNull.Value ? (decimal)fieldValue["col_a6"] : 0;

                Records.Add(record);
            }

            BaseClear();
        }

        public void Save(bool clear_all_before_save /*= true*/)
        {
            BaseBeginTransaction();

            if (clear_all_before_save)
                BaseDelete(Owner.UnigueID);

            foreach (Record record in Records)
            {
                Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                fieldValue.Add("col_a3", record.НомерРядка);
                fieldValue.Add("col_a7", record.НазваТовару);
                fieldValue.Add("col_a4", record.Кількість);
                fieldValue.Add("col_a5", record.Ціна);
                fieldValue.Add("col_a6", record.Сума);

                BaseSave(record.UID, Owner.UnigueID, fieldValue);
            }

            BaseCommitTransaction();
        }

        public void Delete()
        {
            BaseBeginTransaction();
            BaseDelete(Owner.UnigueID);
            BaseCommitTransaction();
        }


        public class Record : DirectoryTablePartRecord
        {
            public Record()
            {
                НомерРядка = 0;
                НазваТовару = "";
                Кількість = 0;
                Ціна = 0;
                Сума = 0;

            }
            public int НомерРядка { get; set; }
            public string НазваТовару { get; set; }
            public int Кількість { get; set; }
            public decimal Ціна { get; set; }
            public decimal Сума { get; set; }

        }
    }


    #endregion

    #region DIRECTORY "Виробники"

    public static class Виробники_Const
    {
        public const string TABLE = "tab_a05";

        public const string Назва = "col_b3";
        public const string Код = "col_b4";
    }


    public class Виробники_Objest : DirectoryObject
    {
        public Виробники_Objest() : base(Config.Kernel, "tab_a05",
             new string[] { "col_b3", "col_b4" })
        {
            Назва = "";
            Код = "";

        }

        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = FieldValue["col_b3"].ToString();
                Код = FieldValue["col_b4"].ToString();

                BaseClear();
                return true;
            }
            else
                return false;
        }

        public void Save()
        {
            FieldValue["col_b3"] = Назва;
            FieldValue["col_b4"] = Код;

            BaseSave();

        }

        public Виробники_Objest Copy()
        {
            Виробники_Objest copy = new Виробники_Objest();
            copy.New();
            copy.Назва = Назва;
            copy.Код = Код;

            return copy;
        }

        public void Delete()
        {

            BaseDelete(new string[] { });
        }

        public Виробники_Pointer GetDirectoryPointer()
        {
            Виробники_Pointer directoryPointer = new Виробники_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }

        public string Назва { get; set; }
        public string Код { get; set; }

    }


    public class Виробники_Pointer : DirectoryPointer
    {
        public Виробники_Pointer(object uid = null) : base(Config.Kernel, "tab_a05")
        {
            Init(new UnigueID(uid), null);
        }

        public Виробники_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a05")
        {
            Init(uid, fields);
        }

        public Виробники_Objest GetDirectoryObject()
        {
            if (IsEmpty()) return null;
            Виробники_Objest ВиробникиObjestItem = new Виробники_Objest();
            return ВиробникиObjestItem.Read(UnigueID) ? ВиробникиObjestItem : null;
        }

        public Виробники_Pointer GetNewDirectoryPointer()
        {
            return new Виробники_Pointer(UnigueID);
        }

        public string GetPresentation()
        {
            return BasePresentation(
                new string[] { "col_b3" }
            );
        }

        public Виробники_Pointer GetEmptyPointer()
        {
            return new Виробники_Pointer();
        }
    }


    public class Виробники_Select : DirectorySelect
    {
        public Виробники_Select() : base(Config.Kernel, "tab_a05") { }
        public bool Select() { return BaseSelect(); }

        public bool SelectSingle() { if (BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }

        public bool MoveNext() { if (MoveToPosition()) { Current = new Виробники_Pointer(DirectoryPointerPosition.UnigueID, DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Виробники_Pointer Current { get; private set; }

        public Виробники_Pointer FindByField(string name, object value)
        {
            Виробники_Pointer itemPointer = new Виробники_Pointer();
            DirectoryPointer directoryPointer = BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }

        public List<Виробники_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Виробники_Pointer> directoryPointerList = new List<Виробники_Pointer>();
            foreach (DirectoryPointer directoryPointer in BaseFindListByField(name, value, limit, offset))
                directoryPointerList.Add(new Виробники_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }



    #endregion

}

namespace НоваКонфігурація_1_0.Перелічення
{

    #region ENUM "ТипНоменклатури"

    public enum ТипНоменклатури
    {
        Товар = 1,
        Послуга = 2
    }
    #endregion

}

namespace НоваКонфігурація_1_0.Документи
{

    #region DOCUMENT "ПоступленняТоварів"

    public static class ПоступленняТоварів_Const
    {
        public const string TABLE = "tab_a03";

        public const string Назва = "docname";
        public const string ДатаДок = "docdate";
        public const string НомерДок = "docnomer";
    }


    public class ПоступленняТоварів_Objest : DocumentObject
    {
        public ПоступленняТоварів_Objest() : base(Config.Kernel, "tab_a03", "ПоступленняТоварів",
             new string[] { "docname", "docdate", "docnomer" })
        {
            Назва = "";
            ДатаДок = DateTime.MinValue;
            НомерДок = "";

            //Табличні частини
            Товари_TablePart = new ПоступленняТоварів_Товари_TablePart(this);
            Послуги_TablePart = new ПоступленняТоварів_Послуги_TablePart(this);

        }

        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = FieldValue["docname"].ToString();
                ДатаДок = FieldValue["docdate"] != DBNull.Value ? DateTime.Parse(FieldValue["docdate"].ToString()) : DateTime.MinValue;
                НомерДок = FieldValue["docnomer"].ToString();

                BaseClear();
                return true;
            }
            else
                return false;
        }

        public void Save()
        {
            FieldValue["docname"] = Назва;
            FieldValue["docdate"] = ДатаДок;
            FieldValue["docnomer"] = НомерДок;

            BaseSave();

        }

        public void SpendTheDocument(DateTime spendDate)
        {
            BaseSpend(false, DateTime.MinValue);
        }

        public void ClearSpendTheDocument()
        {
            BaseSpend(false, DateTime.MinValue);
        }

        public ПоступленняТоварів_Objest Copy()
        {
            ПоступленняТоварів_Objest copy = new ПоступленняТоварів_Objest();
            copy.New();
            copy.Назва = Назва;
            copy.ДатаДок = ДатаДок;
            copy.НомерДок = НомерДок;

            return copy;
        }

        public void Delete()
        {

            BaseDelete(new string[] { "tab_a04", "tab_a08" });
        }

        public ПоступленняТоварів_Pointer GetDocumentPointer()
        {
            ПоступленняТоварів_Pointer directoryPointer = new ПоступленняТоварів_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }

        public string Назва { get; set; }
        public DateTime ДатаДок { get; set; }
        public string НомерДок { get; set; }

        //Табличні частини
        public ПоступленняТоварів_Товари_TablePart Товари_TablePart { get; set; }
        public ПоступленняТоварів_Послуги_TablePart Послуги_TablePart { get; set; }

    }


    public class ПоступленняТоварів_Pointer : DocumentPointer
    {
        public ПоступленняТоварів_Pointer(object uid = null) : base(Config.Kernel, "tab_a03", "ПоступленняТоварів")
        {
            Init(new UnigueID(uid), null);
        }

        public ПоступленняТоварів_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a03", "ПоступленняТоварів")
        {
            Init(uid, fields);
        }

        public string GetPresentation()
        {
            return BasePresentation(
                new string[] { "docname" }
            );
        }

        public ПоступленняТоварів_Pointer GetNewDocumentPointer()
        {
            return new ПоступленняТоварів_Pointer(UnigueID);
        }

        public ПоступленняТоварів_Pointer GetEmptyPointer()
        {
            return new ПоступленняТоварів_Pointer();
        }

        public ПоступленняТоварів_Objest GetDocumentObject(bool readAllTablePart = false)
        {
            ПоступленняТоварів_Objest ПоступленняТоварівObjestItem = new ПоступленняТоварів_Objest();
            ПоступленняТоварівObjestItem.Read(UnigueID);

            if (readAllTablePart)
            {
                ПоступленняТоварівObjestItem.Товари_TablePart.Read(); ПоступленняТоварівObjestItem.Послуги_TablePart.Read();
            }

            return ПоступленняТоварівObjestItem;
        }
    }


    public class ПоступленняТоварів_Select : DocumentSelect
    {
        public ПоступленняТоварів_Select() : base(Config.Kernel, "tab_a03") { }

        public bool Select() { return BaseSelect(); }

        public bool SelectSingle() { if (BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }

        public bool MoveNext() { if (MoveToPosition()) { Current = new ПоступленняТоварів_Pointer(DocumentPointerPosition.UnigueID, DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public ПоступленняТоварів_Pointer Current { get; private set; }
    }


    public class ПоступленняТоварів_Товари_TablePart : DocumentTablePart
    {
        public ПоступленняТоварів_Товари_TablePart(ПоступленняТоварів_Objest owner) : base(Config.Kernel, "tab_a04",
             new string[] { "col_a8", "col_a9", "col_b1", "col_b2" })
        {
            if (owner == null) throw new Exception("owner null");

            Owner = owner;
            Records = new List<Record>();
        }

        public const string Номенклатура = "col_a8";
        public const string Кількість = "col_a9";
        public const string Ціна = "col_b1";
        public const string Сума = "col_b2";

        public ПоступленняТоварів_Objest Owner { get; private set; }

        public List<Record> Records { get; set; }

        public void Read()
        {
            Records.Clear();
            BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in FieldValueList)
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];

                record.Номенклатура = new Довідники.Номенклатура_Pointer(fieldValue["col_a8"]);
                record.Кількість = fieldValue["col_a9"] != DBNull.Value ? (int)fieldValue["col_a9"] : 0;
                record.Ціна = fieldValue["col_b1"] != DBNull.Value ? (decimal)fieldValue["col_b1"] : 0;
                record.Сума = fieldValue["col_b2"] != DBNull.Value ? (decimal)fieldValue["col_b2"] : 0;

                Records.Add(record);
            }

            BaseClear();
        }

        public void Save(bool clear_all_before_save /*= true*/)
        {
            BaseBeginTransaction();

            if (clear_all_before_save)
                BaseDelete(Owner.UnigueID);

            foreach (Record record in Records)
            {
                Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                fieldValue.Add("col_a8", record.Номенклатура.UnigueID.UGuid);
                fieldValue.Add("col_a9", record.Кількість);
                fieldValue.Add("col_b1", record.Ціна);
                fieldValue.Add("col_b2", record.Сума);

                BaseSave(record.UID, Owner.UnigueID, fieldValue);
            }

            BaseCommitTransaction();
        }

        public void Delete()
        {
            BaseBeginTransaction();
            BaseDelete(Owner.UnigueID);
            BaseCommitTransaction();
        }

        public List<Record> Copy()
        {
            List<Record> copyRecords = new List<Record>();
            copyRecords = Records;

            foreach (Record copyRecordItem in copyRecords)
                copyRecordItem.UID = Guid.Empty;

            return copyRecords;
        }

        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Номенклатура = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Ціна = 0;
                Сума = 0;

            }
            public Довідники.Номенклатура_Pointer Номенклатура { get; set; }
            public int Кількість { get; set; }
            public decimal Ціна { get; set; }
            public decimal Сума { get; set; }

        }
    }

    public class ПоступленняТоварів_Послуги_TablePart : DocumentTablePart
    {
        public ПоступленняТоварів_Послуги_TablePart(ПоступленняТоварів_Objest owner) : base(Config.Kernel, "tab_a08",
             new string[] { "col_a1", "col_a2", "col_a3", "col_a4" })
        {
            if (owner == null) throw new Exception("owner null");

            Owner = owner;
            Records = new List<Record>();
        }

        public const string Послуга = "col_a1";
        public const string Кількість = "col_a2";
        public const string Ціна = "col_a3";
        public const string Сума = "col_a4";

        public ПоступленняТоварів_Objest Owner { get; private set; }

        public List<Record> Records { get; set; }

        public void Read()
        {
            Records.Clear();
            BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in FieldValueList)
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];

                record.Послуга = new Довідники.Номенклатура_Pointer(fieldValue["col_a1"]);
                record.Кількість = fieldValue["col_a2"] != DBNull.Value ? (int)fieldValue["col_a2"] : 0;
                record.Ціна = fieldValue["col_a3"] != DBNull.Value ? (decimal)fieldValue["col_a3"] : 0;
                record.Сума = fieldValue["col_a4"] != DBNull.Value ? (decimal)fieldValue["col_a4"] : 0;

                Records.Add(record);
            }

            BaseClear();
        }

        public void Save(bool clear_all_before_save /*= true*/)
        {
            BaseBeginTransaction();

            if (clear_all_before_save)
                BaseDelete(Owner.UnigueID);

            foreach (Record record in Records)
            {
                Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                fieldValue.Add("col_a1", record.Послуга.UnigueID.UGuid);
                fieldValue.Add("col_a2", record.Кількість);
                fieldValue.Add("col_a3", record.Ціна);
                fieldValue.Add("col_a4", record.Сума);

                BaseSave(record.UID, Owner.UnigueID, fieldValue);
            }

            BaseCommitTransaction();
        }

        public void Delete()
        {
            BaseBeginTransaction();
            BaseDelete(Owner.UnigueID);
            BaseCommitTransaction();
        }

        public List<Record> Copy()
        {
            List<Record> copyRecords = new List<Record>();
            copyRecords = Records;

            foreach (Record copyRecordItem in copyRecords)
                copyRecordItem.UID = Guid.Empty;

            return copyRecords;
        }

        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Послуга = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Ціна = 0;
                Сума = 0;

            }
            public Довідники.Номенклатура_Pointer Послуга { get; set; }
            public int Кількість { get; set; }
            public decimal Ціна { get; set; }
            public decimal Сума { get; set; }

        }
    }


    #endregion

}

namespace НоваКонфігурація_1_0.Журнали
{
    #region Journal
    public class Journal_Select : JournalSelect
    {
        public Journal_Select() : base(Config.Kernel,
             new string[] { "tab_a03" },
             new string[] { "ПоступленняТоварів" })
        { }

        public DocumentObject GetDocumentObject(bool readAllTablePart = true)
        {
            if (Current == null)
                return null;

            switch (Current.TypeDocument)
            {
                case "ПоступленняТоварів": return new Документи.ПоступленняТоварів_Pointer(Current.UnigueID).GetDocumentObject(readAllTablePart);

            }

            return null;
        }
    }
    #endregion

}

namespace НоваКонфігурація_1_0.РегістриВідомостей
{

    #region REGISTER "ЦіниНоменклатури"

    public static class ЦіниНоменклатури_Const
    {
        public const string TABLE = "tab_a07";

        public const string Номенклатура = "col_b7";
        public const string Ціна = "col_b8";
    }


    public class ЦіниНоменклатури_RecordsSet : RegisterInformationRecordsSet
    {
        public ЦіниНоменклатури_RecordsSet() : base(Config.Kernel, "tab_a07",
             new string[] { "col_b7", "col_b8" })
        {
            Records = new List<Record>();
        }

        public List<Record> Records { get; set; }

        public void Read()
        {
            Records.Clear();
            BaseRead();
            foreach (Dictionary<string, object> fieldValue in FieldValueList)
            {
                Record record = new Record();

                record.UID = (Guid)fieldValue["uid"];
                record.Period = DateTime.Parse(fieldValue["period"].ToString());
                record.Owner = (Guid)fieldValue["owner"];
                record.Номенклатура = new Довідники.Номенклатура_Pointer(fieldValue["col_b7"]);
                record.Ціна = fieldValue["col_b8"] != DBNull.Value ? (decimal)fieldValue["col_b8"] : 0;

                Records.Add(record);
            }
            BaseClear();
        }

        public void Save(DateTime period, Guid owner)
        {
            BaseBeginTransaction();
            BaseDelete(owner);
            foreach (Record record in Records)
            {
                record.Period = period;
                record.Owner = owner;
                Dictionary<string, object> fieldValue = new Dictionary<string, object>();
                fieldValue.Add("col_b7", record.Номенклатура.UnigueID.UGuid);
                fieldValue.Add("col_b8", record.Ціна);

                BaseSave(record.UID, period, owner, fieldValue);
            }
            BaseCommitTransaction();
        }

        public void Delete(Guid owner)
        {
            BaseBeginTransaction();
            BaseDelete(owner);
            BaseCommitTransaction();
        }


        public class Record : RegisterInformationRecord
        {
            public Record()
            {
                Номенклатура = new Довідники.Номенклатура_Pointer();
                Ціна = 0;

            }

            public Довідники.Номенклатура_Pointer Номенклатура { get; set; }
            public decimal Ціна { get; set; }

        }
    }


    public class ЦіниНоменклатури_Objest : RegisterInformationObject
    {
        public ЦіниНоменклатури_Objest() : base(Config.Kernel, "tab_a07",
             new string[] { "col_b7", "col_b8" })
        {
            Номенклатура = new Довідники.Номенклатура_Pointer();
            Ціна = 0;

        }

        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Номенклатура = new Довідники.Номенклатура_Pointer(FieldValue["col_b7"]);
                Ціна = FieldValue["col_b8"] != DBNull.Value ? (decimal)FieldValue["col_b8"] : 0;

                BaseClear();
                return true;
            }
            else
                return false;
        }

        public void Save()
        {
            FieldValue["col_b7"] = Номенклатура.UnigueID.UGuid;
            FieldValue["col_b8"] = Ціна;

            BaseSave();
        }

        public ЦіниНоменклатури_Objest Copy()
        {
            ЦіниНоменклатури_Objest copy = new ЦіниНоменклатури_Objest();
            copy.New();
            copy.Номенклатура = Номенклатура;
            copy.Ціна = Ціна;

            return copy;
        }

        public void Delete()
        {
            BaseDelete();
        }

        public Довідники.Номенклатура_Pointer Номенклатура { get; set; }
        public decimal Ціна { get; set; }

    }

    #endregion

}

namespace НоваКонфігурація_1_0.РегістриНакопичення
{

    #region REGISTER "ТовариНаСкладах"

    public static class ТовариНаСкладах_Const
    {
        public const string TABLE = "tab_a06";
        public static readonly string[] AllowDocumentSpendTable = new string[] { };
        public static readonly string[] AllowDocumentSpendType = new string[] { };

        public const string Номенклатура = "col_b5";
        public const string Кількість = "col_b6";
    }


    public class ТовариНаСкладах_RecordsSet : RegisterAccumulationRecordsSet
    {
        public ТовариНаСкладах_RecordsSet() : base(Config.Kernel, "tab_a06",
             new string[] { "col_b5", "col_b6" })
        {
            Records = new List<Record>();
        }

        public List<Record> Records { get; set; }

        public void Read()
        {
            Records.Clear();

            BaseRead();

            foreach (Dictionary<string, object> fieldValue in FieldValueList)
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                record.Period = DateTime.Parse(fieldValue["period"].ToString());
                record.Income = (bool)fieldValue["income"];
                record.Owner = (Guid)fieldValue["owner"];
                record.Номенклатура = new Довідники.Номенклатура_Pointer(fieldValue["col_b5"]);
                record.Кількість = fieldValue["col_b6"] != DBNull.Value ? (decimal)fieldValue["col_b6"] : 0;

                Records.Add(record);
            }

            BaseClear();
        }

        public void Save(DateTime period, Guid owner)
        {
            BaseBeginTransaction();
            BaseDelete(owner);
            foreach (Record record in Records)
            {
                record.Period = period;
                record.Owner = owner;
                Dictionary<string, object> fieldValue = new Dictionary<string, object>();
                fieldValue.Add("col_b5", record.Номенклатура.UnigueID.UGuid);
                fieldValue.Add("col_b6", record.Кількість);

                BaseSave(record.UID, period, record.Income, owner, fieldValue);
            }
            BaseCommitTransaction();
        }

        public void Delete(Guid owner)
        {
            BaseBeginTransaction();
            BaseDelete(owner);
            BaseCommitTransaction();
        }


        public class Record : RegisterAccumulationRecord
        {
            public Record()
            {
                Номенклатура = new Довідники.Номенклатура_Pointer();
                Кількість = 0;

            }
            public Довідники.Номенклатура_Pointer Номенклатура { get; set; }
            public decimal Кількість { get; set; }

        }
    }

    #endregion

}
