using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace Laga.IO
{
    public class IOExcelRead
    {
        private string filePath;
        private int sheetNum;
        private string xlsxRange;

        private Excel.Application excelApp;
        private Excel.Workbook xlBook;
        private Excel.Worksheet xlSheet;
        private Excel.Range xlRange;

        private List<List<string>> dataExcel = new List<List<string>>();

        #region public properties

        /// <summary>
        /// get the data by list format, use this to get the data from excel
        /// </summary>
        public List<List<string>> matrixDataExcel
        {
            get
            {
                return dataExcel;
            }

        }

        public int SheetNum
        {
            get
            {
                return sheetNum;
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// The simpliest constructor
        /// </summary>
        /// <param name="FilePath">string, the path to the file</param>
        public IOExcelRead(string FilePath)
        {
            this.filePath = FilePath;
        }

        /// <summary>
        /// Constructor for IOExcel most flexible constructor.
        /// therfore you have to deal with all operations:
        /// open, read or write and close.
        /// </summary>
        /// <param name="FilePath">String, the Path to the file</param>
        /// <param name="SheetNumber">Integer, the index sheet in the excel book</param>
        public IOExcelRead(string FilePath, int SheetNumber)
        {
            this.filePath = FilePath;
            this.sheetNum = SheetNumber;
        }

        /// <summary>
        /// Simple constructor to read data straightforward from excel
        /// the simpliest and faster option
        /// </summary>
        /// <param name="FilePath">string, the Path to the file</param>
        /// <param name="SheetNumber">integer, the index sheet in the excel book</param>
        /// <param name="XlsxRange">string, the excel range to read the data</param>
        public IOExcelRead(string FilePath, int SheetNumber, string XlsxRange)
        {
            this.filePath = FilePath;
            this.sheetNum = SheetNumber;
            this.xlsxRange = XlsxRange;

            IORead_OpenExcelApp(false);

            IOReadRange(xlsxRange);
            CloseExcelApp(false);
        }

        #endregion

        #region methods to read excel
        /// <summary>
        /// it will read the range specified in the constructor.
        /// </summary>
        /// <param name="strXlRange">the range to read the excel, format "A1:B2" if is empty ("") will return the whole data in the workbook</param>
        public void IOReadRange(string strXlRange)
        {
            xlRange = (strXlRange == "") ? xlSheet.UsedRange : xlSheet.Range[strXlRange];

            object[,] cellValues = (object[,])xlRange.Value2;
            List<string> lst;
            string str;

            for (int i = 1; i <= cellValues.GetLength(0); i++)
            {
                lst = new List<string>();
                for (int j = 1; j <= cellValues.GetLength(1); j++)
                {
                    str = (cellValues[i, j] != null) ? cellValues[i, j].ToString() : "!=";
                    lst.Add(str);
                }
                dataExcel.Add(lst);
            }
        }

        /// <summary>
        /// Read an specific cell in excel.
        /// </summary>
        /// <param name="strXlCell">the range to read the excel, format "A1"</param>
        public void IOReadCell(string strXlCell)
        {
            xlRange = xlSheet.Range[strXlCell];
            object obDta = (object)xlRange.Value2;
            string str = (obDta != null) ? obDta.ToString() : "!=";
            List<string> lst = new List<string>() { str };
            dataExcel.Add(lst);
        }

        #endregion

        #region open and close excel application

        public void IOWrite_SetActiveSheet(int pos, bool display)
        {
            Excel.Sheets excelSheets = xlBook.Worksheets;
            xlSheet = excelSheets.Item[pos];
            xlSheet.Activate();

            if (display)
                xlSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;
        }

        /// <summary>
        /// Test if excel application is open.
        /// </summary>
        public bool TestExcelOpen()
        {
            bool open = true;
            try
            {
                Excel.Application exApp;
                exApp = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
                exApp.Workbooks.get_Item(sheetNum);
                open = true;
            }
            catch
            {
                open = false;
            }
            return open;
        }

        /// <summary>
        /// Open the App
        /// return all the excelfile names.
        /// Close the App, release the Marshalls.
        /// </summary>
        public List<string> IORead_ExcelWorksheetNames()
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);
            List<string> lstExcelNames = new List<string>();
            foreach (Excel.Worksheet ws in xlBook.Worksheets)
            {
                lstExcelNames.Add(ws.Name);
            }
            CloseExcelApp(false);

            return lstExcelNames; //check the sheetnumber...
        }

        public void IORead_OpenExcelApp()
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);
            sheetNum = excelApp.Worksheets.Count;
        }

        /// <summary>
        /// open excel based on the constructor.
        /// </summary>
        /// <param name="display">if is true, show the excel"</param>
        public void IORead_OpenExcelApp(bool display)
        {
            excelApp = new Excel.Application();
            xlBook = excelApp.Workbooks.Open(filePath);

            if (display)
            {
                excelApp.Visible = display;
                excelApp.WindowState = Excel.XlWindowState.xlMaximized;
            }

            int c = excelApp.Worksheets.Count; //check the sheetnumber...
            if ((sheetNum > c) || (sheetNum < 1)) //means there is no excel sheet to read.
            {
                //System.Windows.Forms.MessageBox.Show("No excel Sheet found");
                CloseExcelApp();
            }
            else
            {
                xlSheet = xlBook.Sheets[sheetNum];
            }
        }

        /// <summary>
        /// clean all the marshalls and kill excel.
        /// </summary>
        public void CloseExcelApp()
        {
            //clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);  //kill the range..
            Marshal.ReleaseComObject(xlSheet);  //kill the sheet used

            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp); //kill the excel
        }

        /// <summary>
        /// clean all the marshalls and close - save the excel.
        /// </summary>
        /// <param name="saveFile">if is true, will save the file</param>
        public void CloseExcelApp(bool saveFile)
        {
            //clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excell process
            if (xlRange != null)
            { Marshal.ReleaseComObject(xlRange); } //kill the range..

            if (xlSheet != null)
            { Marshal.ReleaseComObject(xlSheet); } //kill the sheet used

            if (xlBook != null)
            {
                xlBook.Close(saveFile, Type.Missing, Type.Missing);
                Marshal.ReleaseComObject(xlBook); //kill the file
            }

            if (excelApp != null)
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp); //kill the excel
            }
        }

        /// <summary>
        /// save and close the excel.
        /// </summary>
        /// <param name="saveFile">if is true, will save the file</param>
        /// <param name="fileName">string, the file name of the excel file</param>
        /// <param name="directory">string, the address where to save the excel</param>
        public void CloseExcelApp(bool saveFile, string fileName, string directory)
        {
            //clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excell process
            if (xlRange != null)
            { Marshal.ReleaseComObject(xlRange); } //kill the range..

            if (xlSheet != null)
            { Marshal.ReleaseComObject(xlSheet); } //kill the sheet used

            if (xlBook != null)
            {
                xlBook.Close(saveFile, fileName, directory);
                Marshal.ReleaseComObject(xlBook); //kill the file
            }

            if (excelApp != null)
            {
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp); //kill the excel
            }
        }
        #endregion

    }
}
