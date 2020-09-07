using Microsoft.Office.Interop.Excel;
using Kouzi.Scripts.Model;

namespace Kouzi.Scripts.Other
{
    /// <summary>
    /// Class for equipment sheet.
    /// </summary>
    public class EquipmentSheet : SheetBase
    {

        #region Constants

        private const string SHEET_NAME = "Оборудование";

        #endregion

        public override void SetData()
        {
            data = new object[rows, columns];
            for (int i = 1; i < rows; i++)
            {
                Equipment equip = App.EquipmentsResultPageVM.EquipmentsList[i - 1];
                data[i, Equipment.EQUIP_NAME_INDEX] = equip.Name;
                data[i, Equipment.EQUIP_COUNT_INDEX] = equip.Count;
                data[i, Equipment.EQUIP_COST_INDEX] = equip.Cost;
                data[i, Equipment.EQUIP_SUM_INDEX] = equip.Sum;
                data[i, Equipment.EQUIP_MYCOST_INDEX] = equip.MyCost;
                data[i, Equipment.EQUIP_MYSUM_INDEX] = equip.MySum;
                data[i, Equipment.EQUIP_DIFF_INDEX] = equip.Diff;
            }
        }

        public override void SetDataSize()
        {
            App.EquipmentsResultPageVM.SetEquipmentsList();
            columns = 7;
            rows = App.EquipmentsResultPageVM.EquipmentsList.Count + 1;
        }

        public override void SetSheet()
        {
            SetSheetContent();
            SetAlignment(rows + 1);
            SetButtomLine(rows);
            SetVerticalLines(rows, columns + 1);
            Sheet.Columns.AutoFit();
        }

        private void SetSheetContent()
        {
            Sheet.Name = SHEET_NAME;
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
        }

        public override void SetTitle(int index)
        {
            for(int i = 3; i < title.Length - 1; i++)
            {
                data[0, i - 3] = title[i];
                data[0, i - 3] = data[0, i - 3].ToString().Replace($"{i + 1}.", "");
            }
            SetTitleLine();
        }
    }
}
