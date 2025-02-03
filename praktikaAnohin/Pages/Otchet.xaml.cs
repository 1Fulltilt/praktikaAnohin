using praktikaAnohin.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktikaAnohin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Page
    {
        public Otchet()
        {
            InitializeComponent();
        }

        private void vivod_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Microsoft.Office.Interop.Excel.Workbook work = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "pomogite";

            // Заголовки столбцов
            sheet.Cells[1, 1] = "ID авто";
            sheet.Cells[1, 2] = "Марка авто";
            sheet.Cells[1, 3] = "Модель авто";
            sheet.Cells[1, 4] = "Государственный знак";
            sheet.Cells[1, 5] = "Владелец";
            sheet.Cells[1, 6] = "Телефон";
            sheet.Cells[1, 7] = "Охранник";
            sheet.Cells[1, 8] = "Телефон";
            sheet.Cells[1, 9] = "Дата";

            // Заполнение данных
            var currentRow = 2;
           
            foreach (var currectID in connect.context.id_)
            {
                var ohrana = connect.context.Ohrana.FirstOrDefault(x => x.id_storozha == currectID.id_storozha);
                var Prhod_uhod = connect.context.Prihod___uhod_avto.FirstOrDefault(x => x.id_zapisi == currectID.id_zapisi);
                var Spiski_vladelca = connect.context.Spiski_vladelca.FirstOrDefault(x => x.id_vladelca == currectID.id_vladelca);
                var Spisok_Avto = connect.context.Spisok_Avto.FirstOrDefault(x => x.Id_avto == currectID.id_avto);

                
                sheet.Cells[currentRow, 1] = currectID.id;
                sheet.Cells[currentRow, 2] = Spisok_Avto.marka_avto;
                sheet.Cells[currentRow, 3] = Spisok_Avto.model_avto;
                sheet.Cells[currentRow, 4] = Spisok_Avto.gos_znak;
                sheet.Cells[currentRow, 5] = Spiski_vladelca.FIO;
                sheet.Cells[currentRow, 6] = Spiski_vladelca.Telefon;
                sheet.Cells[currentRow, 7] = ohrana.FIO;
                sheet.Cells[currentRow, 8] = ohrana.Telefon;
                sheet.Cells[currentRow, 9] = Prhod_uhod.data;
                currentRow++;
            }

            Microsoft.Office.Interop.Excel.Range rang = sheet.get_Range("A1", "I" + (currentRow).ToString());
            rang.Cells.Font.Name = "Times New Roman";
            rang.Font.Size = 14;
            rang.Font.Bold = true;
        }
    }
}
