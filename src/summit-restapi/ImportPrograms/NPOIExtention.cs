using NPOI.SS.UserModel;
using System;

namespace ImportPrograms
{
    public static class NPOIExtention
    {
        public static string Value(this ICell cell)
        {
            try
            {
                switch (cell.CellType)
                {
                    case CellType.Numeric:
                        return cell.NumericCellValue.ToString();
                    case CellType.String:
                        return cell.StringCellValue;
                    case CellType.Blank:
                        return "";
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
