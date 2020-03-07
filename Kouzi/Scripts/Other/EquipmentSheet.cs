using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kouzi.Scripts.Model;

namespace Kouzi.Scripts.Other
{
    public class EquipmentSheet : SheetBase
    {

        public override void SetData(ref object[,] data)
        {
            data = new object[rows, columns];
            for (int i = 1; i < rows; i++)
            {
                Equipment equip = App.EquipmentsResultPageVM.EquipmentsList[i - 1];
                data[i, 0] = equip.Name;
                data[i, 1] = equip.Count;
                data[i, 2] = equip.Cost;
                data[i, 3] = equip.Sum;
                data[i, 4] = equip.MyCost;
                data[i, 5] = equip.MySum;
                data[i, 6] = equip.Diff;
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
            Sheet.Name = "Оборудование";
            Range start = (Range)Sheet.Cells[1, 1];
            Range end = (Range)Sheet.Cells[rows, columns];
            Sheet.Range[start, end].Value2 = GetData();
            SetAlignment(rows + 1);
            SetButtomLine(rows);
            SetVerticalLines(rows, columns + 1);
            Sheet.Columns.AutoFit();
        }

        public override void SetTitle(ref object[,] data, int index)
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
