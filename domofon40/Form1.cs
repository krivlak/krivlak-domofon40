using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace domofon40
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
        }

        private void поселкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_поселков списокПоселков = new список_поселков();
            списокПоселков.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void заданияМонтажникамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {
                    клВид_услуги.выбран = false;
                    пометитьVуслуги ОтметитьУслуги = new пометитьVуслуги();
                    ОтметитьУслуги.ShowDialog();
                    if (клВид_услуги.выбран)
                    {
                        Cursor = Cursors.WaitCursor;
                        монтажникам_повтор графикМонтажникам = new монтажникам_повтор();
                        графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                                 + " в доме № "
                                                 + клДом.номер.ToString() + клДом.корпус
                                                 + " по улице " + клДом.deRow.улицы.наимен;

                        графикМонтажникам.ShowDialog();
                        Cursor = Cursors.Default;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void смс1ДомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //клДом.выбран = false;
            //выбор_дома ВыборДома = new выбор_дома();
            //ВыборДома.ShowDialog();
            //if (клДом.выбран)
            //{
            //    Cursor = Cursors.WaitCursor;
            //    смс1дом графикМонтажникам = new смс1дом();
            //    графикМонтажникам.Text = " Долги в доме № "
            //                             + клДом.номер.ToString() + клДом.корпус
            //                             + " по улице " + клДом.deRow.улицы.наимен;

            //    графикМонтажникам.ShowDialog();

            //}
            //Cursor = Cursors.Default;

        }



        private void списокСообщенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_звонков формаЗвонки = new список_звонков();
            формаЗвонки.ShowDialog();
            Cursor = Cursors.Default;
        }

        //private void списокРазрешенийToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Cursor = Cursors.WaitCursor;
        //    ввод_разрешений формаЗвонки = new ввод_разрешений();
        //    формаЗвонки.ShowDialog();
        //    Cursor = Cursors.Default;
        //}





        private void улицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клПоселок.выбран = false;
            выбор_поселка ВыборПоселка = new выбор_поселка();
            ВыборПоселка.ShowDialog();
            if (ВыборПоселка.DialogResult== DialogResult.OK)
            {
                список_улиц формаУлица = new список_улиц();
                формаУлица.Text = "Список улиц в " + клПоселок.deRow.наимен;
                формаУлица.ShowDialog();
            }
        }

        private void домаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клУлица.выбран = false;
            выбор_улицы ВыборУлицы = new выбор_улицы();
            ВыборУлицы.ShowDialog();
            if (клУлица.выбран)
            {
                Cursor = Cursors.WaitCursor;
                список_домов формаДом = new список_домов();
                формаДом.Text = "Список домов на обслуживании п. " + клУлица.deRow.поселки.наимен.Trim() + " ул. " + клУлица.наимен;
                формаДом.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_видов формаДом = new список_видов();
            формаДом.ShowDialog();
            Cursor = Cursors.Default;

        }

        private void пробаViewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //проба_виды пробаВиды = new проба_виды();
            //пробаВиды.ShowDialog();
        }

        private void работыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            список_работ списокРабот = new список_работ();
            списокРабот.ShowDialog();
        }

        private void стоимостьОбслуживанияToolStripMenuItem_Click(object sender, EventArgs e)
        {


            клУслуга.выбран = false;
            выбор_услуги выборУслуги = new выбор_услуги();
            выборУслуги.ShowDialog();
            if (клУслуга.выбран || выборУслуги.DialogResult== DialogResult.OK)
            {
                //  ввод2тарифов формаЦены = new ввод2тарифов();
                история_тарифов формаЦены = new история_тарифов();
                формаЦены.Text = "Стоимомость за месяц " + клУслуга.наимен;
                формаЦены.ShowDialog();
            }



        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран || выборВида.DialogResult == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                список_услуг списокУслуг = new список_услуг();
                списокУслуг.Text = " Список услуг вида " + клВид_услуги.deRow.наимен;
                списокУслуг.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void менеджерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_сотрудников списокУслуг = new список_сотрудников();
            списокУслуг.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void квартирыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //while (true)
            //{
            клДом.выбран = false;
            выбор_дома ВыборДома = new выбор_дома();
            ВыборДома.ShowDialog();
            if (клДом.выбран)
            {
                Cursor = Cursors.WaitCursor;
                список_квартир графикМонтажникам = new список_квартир();
                графикМонтажникам.Text = " Квартиры  в доме № "
                                         + клДом.номер.ToString() + клДом.корпус
                                         + " по улице " + клДом.deRow.улицы.наимен;

                графикМонтажникам.ShowDialog();
                Cursor = Cursors.Default;
            }


            //}
            Cursor = Cursors.Default;

        }



        //private void заданиеНаОтключениеПоДомуToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    клВид_услуги.выбран = false;
        //    выбор_вида_услуги выборВида = new выбор_вида_услуги();
        //    выборВида.ShowDialog();
        //    if (клВид_услуги.выбран)
        //    {
        //        клДом.выбран = false;
        //        выбор_дома ВыборДома = new выбор_дома();
        //        ВыборДома.ShowDialog();
        //        if (клДом.выбран)
        //        {
        //            клВид_услуги.выбран = false;
        //            отметитьVуслуги ОтметитьУслуги = new отметитьVуслуги();
        //            ОтметитьУслуги.ShowDialog();
        //            if (клВид_услуги.выбран)
        //            {
        //                Cursor = Cursors.WaitCursor;
        //                монтажникам1отключить графикМонтажникам = new монтажникам1отключить();
        //                графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
        //                                         + " в доме № "
        //                                         + клДом.номер.ToString() + клДом.корпус
        //                                         + " по улице " + клДом.deRow.улицы.наимен;

        //                графикМонтажникам.ShowDialog();
        //                Cursor = Cursors.Default;
        //            }
        //        }
        //    }
        //}

        private void ggggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {
                    клВид_услуги.выбран = false;
                    отметитьVуслуги ОтметитьУслуги = new отметитьVуслуги();
                    ОтметитьУслуги.ShowDialog();
                    if (клВид_услуги.выбран)
                    {
                        Cursor = Cursors.WaitCursor;
                        отключения1дом графикМонтажникам = new отключения1дом();
                        графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                                 + " в доме № "
                                                 + клДом.номер.ToString() + клДом.корпус
                                                 + " по улице " + клДом.deRow.улицы.наимен;

                        графикМонтажникам.ShowDialog();
                        Cursor = Cursors.Default;
                    }
                }
            }

        }

        private void филиалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            реквизиты_филиала списокФилиалов = new реквизиты_филиала();
            списокФилиалов.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void началоУчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            начало_учета началоУчета = new начало_учета();
            началоУчета.ShowDialog();
        }

        private void удаленныеОплатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            удаленные_оплаты удаленныеОплаты = new удаленные_оплаты();
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void удаленныеМесяцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            удаленные_месяцы удаленныеОплаты = new удаленные_месяцы();
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        //private void создатьРезервнуюКопиюБазыToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Cursor = Cursors.WaitCursor;
        //    //        domofon10.masterEntities me = new masterEntities();
        //   // Model.domofonEntities me = new Model.domofonEntities();
        //    domofon40.DataClasses1DataContext dc = new DataClasses1DataContext();
        ////    domofon40.domofon14Entities de = new domofon14Entities();
        //    //  Model.domofonEntities de = new Model.domofonEntities();
        //    string командаАрхив = @"BACKUP DATABASE [domofon14] TO  [домофон14] WITH NOFORMAT, INIT,  NAME = N'domofon14-Полная База данных Резервное копирование', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

        //    try
        //    {
        //      //  int tt = me.ExecuteStoreCommand(командаАрхив);
        // //     de.Database.ExecuteSqlCommand(командаАрхив);
        //   //     de.Database.SqlQuery<годы>(командаАрхив);
        //        dc.ExecuteCommand(командаАрхив);
        //        MessageBox.Show("Записана резервная копия базы данных... ", "Архивация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Сбой записи  копии базы данных... ", "Архивация", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    Cursor = Cursors.Default;


        //}

        private void заданиеНаОтключениеПоВидамУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                Cursor = Cursors.WaitCursor;
                по_видам ФормаПо = new по_видам();
                ФормаПо.Text = "Платежи за " + клВид_услуги.наимен;
                ФормаПо.ShowDialog();
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;
        }

        private void заданиеНаОключение1ДомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {

                    Cursor = Cursors.WaitCursor;
                    монтажникам1дом графикМонтажникам = new монтажникам1дом();
                    графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                             + " в доме № "
                                             + клДом.deRow.номер.ToString() + клДом.deRow.корпус
                                             + " по улице " + клДом.deRow.улицы.наимен;

                    графикМонтажникам.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }
            Cursor = Cursors.Default;

        }

        private void статистикаНаДатуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void подключеноОтключеноЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    отключено1период формаАнализ = new отключено1период();
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;
                }

            }

        }

        private void статистикаНаСегодняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            статистика44 формаАнализ = new статистика44();
            формаАнализ.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void договораToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_договоров списокДоговоров = new список_договоров();
            списокДоговоров.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void льготыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_льгот списокЛьгот = new список_льгот();
            списокЛьгот.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void отключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_отключений списокОтключений = new список_отключений();
            списокОтключений.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_повторов списокПовторов = new список_повторов();
            списокПовторов.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void простоиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //список_простоев списокПростоев = new список_простоев();
            //списокПростоев.ShowDialog();
            //Cursor = Cursors.Default;
        }

        private void предупрежденияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //список_предупреждений списокПредупреждений = new список_предупреждений();
            //списокПредупреждений.ShowDialog();
            //Cursor = Cursors.Default;
        }

        private void всеЗвонкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_звонки всеЗвонки = new все_звонки();
            всеЗвонки.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void оплата1Мен1ДеньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клКалендарь.дата = DateTime.Today;
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";
            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                клСотрудник.выбран = false;
                выбор_менеджера выборКассира = new выбор_менеджера();
                выборКассира.ShowDialog();

                if (клСотрудник.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    оплаты1день оплатыДень = new оплаты1день();
                    оплатыДень.Text = "Оплаты за " + клКалендарь.дата.Value.ToLongDateString() + " менеджер " + клСотрудник.фио;
                    оплатыДень.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void реквизитыФирмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            реквизиты реквизитыФирмы = new реквизиты();
            реквизитыФирмы.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void шаблоныДоговоровToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void реестрОплаченыхРаботToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клПериод.выбран = false;
            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                Cursor = Cursors.WaitCursor;
                реестр_опл_работ формаАнализ = new реестр_опл_работ();
                формаАнализ.Text = "Реестр оплаченых работ за "
                    + клПериод.дата_с.ToLongDateString() + "  "
                    + клПериод.дата_по.ToLongDateString();
                формаАнализ.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void суммаРаботЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клПериод.выбран = false;
            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                Cursor = Cursors.WaitCursor;
                работы_период формаАнализ = new работы_период();
                формаАнализ.Text = "Сумма работ за период с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString();
                формаАнализ.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void реестр1МенеджерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клСотрудник.выбран = false;
            выбор2менеджера выборСотрудника = new выбор2менеджера();
            выборСотрудника.ShowDialog();
            if (клСотрудник.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    //выбор_вида_оплат выборВида = new выбор_вида_оплат();
                    //выборВида.ShowDialog();
                    //if (выборВида.DialogResult == DialogResult.OK)
                    //{
                        Cursor = Cursors.WaitCursor;
                    //  реестр_работ формаАнализ = new реестр_работ();
                    работы1менеджер формаАнализ = new работы1менеджер();
//                        формаАнализ.Text = $"Реестр оплаченых работ за { клПериод.дата_с.ToLongDateString()} { клПериод.дата_по.ToLongDateString()} менеджер  {клСотрудник.фио}  вид оплаты {клВид_оплаты.deRow.наимен}";
                    формаАнализ.Text = $"Реестр оплаченых работ за { клПериод.дата_с.ToLongDateString()} { клПериод.дата_по.ToLongDateString()} менеджер  {клСотрудник.фио}  ";
                    формаАнализ.ShowDialog();
                        Cursor = Cursors.Default;
                    //}
                }
            }
            Cursor = Cursors.Default;
        }

        private void числоКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            число_договоров подключеноКлиентов = new число_договоров();
            подключеноКлиентов.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void отчетЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void платежиДомаToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void шаблоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_шаблонов формаШаблоны = new список_шаблонов();
            формаШаблоны.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void заданиеМонтажникамУлицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клУлица.выбран = false;
                выбор_улицы ВыборУлицы = new выбор_улицы();
                ВыборУлицы.ShowDialog();
                if (клУлица.выбран)
                {
                    клВид_услуги.выбран = false;
                    отметитьVуслуги ОтметитьУслуги = new отметитьVуслуги();
                    ОтметитьУслуги.ShowDialog();
                    if (клВид_услуги.выбран)
                    {
                        клДом.выбран = false;
                        выборVдомов выборДома = new выборVдомов();
                        выборДома.Text = "Выберите дома на улице " + клУлица.наимен;
                        выборДома.ShowDialog();
                    }
                    //if (клДом.выбран)
                    //{
                    //}
                }
            }
        }

        private void упркомпанияЗаМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {
                    клМесяц.выбран = false;
                    выбор_месяца выборМесяца = new выбор_месяца();
                    выборМесяца.ShowDialog();
                    if (клМесяц.выбран)
                    {
                        Cursor = Cursors.WaitCursor;
                        дом1месяц графикМонтажникам = new дом1месяц();
                        графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                                 + " в доме № "
                                                 + клДом.номер.ToString() + клДом.корпус
                                                 + " по улице " + клДом.deRow.улицы.наимен
                                                 + " за " + клМесяц.наимен;

                        графикМонтажникам.ShowDialog();
                        Cursor = Cursors.Default;
                    }
                }
            }
            Cursor = Cursors.Default;

        }

        private void платежиУлицыToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void числоДговоровПоПоселкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            договоров_поселок договоровПоселок = new договоров_поселок();
            договоровПоселок.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void числоПодключенийПоПоселкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            подключений_поселок договоровПоселок = new подключений_поселок();
            договоровПоселок.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void отчетЗаПериод1МенеджерToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void резервToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.domofon14ConnectionString))
                {


                    string командаАрхив = @"BACKUP DATABASE [domofon14] TO  [домофон14] WITH NOFORMAT, INIT,  NAME = N'domofon14-Полная База данных Резервное копирование', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                    IDbCommand command = new System.Data.SqlClient.SqlCommand(командаАрхив);
                    command.Connection = conn;
                    conn.Open();
                    int результат = command.ExecuteNonQuery();
                    if (результат == -1)
                    {
                        MessageBox.Show("Записана резервная копия базы данных... ", "Архивация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Сбой записи  копии базы данных... ", "Архивация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сбой записи " + ex.Message);
            }

            Cursor = Cursors.Default;

        }

        private void пробаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            проба_соединения пробаСоединения = new проба_соединения();
            пробаСоединения.ShowDialog();
        }

        private void отчетЗаВыбранныеДниToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





        private void работыЗаМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клМесяц.выбран = false;
            выбор_месяца ВыборМесяца = new выбор_месяца();
            ВыборМесяца.ShowDialog();
            if (клМесяц.выбран || ВыборМесяца.DialogResult== DialogResult.OK)
            {
                DateTime начало = new DateTime(клМесяц.год, клМесяц.месяц, 1);
                int дней = DateTime.DaysInMonth(клМесяц.год, клМесяц.месяц);
                DateTime конец_месяца = new DateTime(клМесяц.год, клМесяц.месяц, дней);
                клПериод.дата_с = начало;
                клПериод.дата_по = конец_месяца;
                Cursor = Cursors.WaitCursor;
                //      работы_мастера работыЗаМесяц = new работы_мастера();
                реестр_опл_работ работыЗаМесяц = new реестр_опл_работ();
                работыЗаМесяц.Text = "Работа мастеров за " + клМесяц.наимен + "  " + клМесяц.год.ToString() + " года";
                работыЗаМесяц.ShowDialog();

                Cursor = Cursors.Default;   

            }


        }

        private void подключенияКУслугамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                подключены1услуга списокКвартир = new подключены1услуга();
                списокКвартир.Text = " Подключены к " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            число_подключений ФормаСтатистика = new число_подключений();
            ФормаСтатистика.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void оплатаПодъездаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клКалендарь.дата = DateTime.Today;
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";
            выборДаты.ShowDialog();
            if (клКалендарь.выбран || выборДаты.DialogResult== DialogResult.OK)
            {
                клСотрудник.выбран = false;
                выбор_менеджера выборКассира = new выбор_менеджера();
                выборКассира.ShowDialog();

                if (клСотрудник.выбран || выборКассира.DialogResult== DialogResult.OK)
                {
                    клОплата.изменено = false;
                    клУслуга.выбран = false;
                    выбор_услуги ВыборУслуги = new выбор_услуги();
                    ВыборУслуги.ShowDialog();
                    if (клУслуга.выбран || ВыборУслуги.DialogResult== DialogResult.OK)
                    {
                        клМесяц.выбран = false;
                        выбор_года ВыборГода = new выбор_года();
                        ВыборГода.ShowDialog();
                        if (клМесяц.выбран || ВыборГода.DialogResult== DialogResult.OK)
                        {
                            клДом.выбран = false;
                            выбор_дома ВыборДома = new выбор_дома();
                            ВыборДома.ShowDialog();
                            if (клДом.выбран || ВыборДома.DialogResult== DialogResult.OK)
                            {
                                клПодъезд.выбран = false;
                                выбор_подъезда ВыборПодъезда = new выбор_подъезда();
                                ВыборПодъезда.ShowDialog();
                                if (клПодъезд.выбран || ВыборПодъезда.DialogResult== DialogResult.OK)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    оплата_подъезда ОплатаПодъезда = new оплата_подъезда();
                                    ОплатаПодъезда.Text = "Оплата подъезда " + клПодъезд.подъезд.ToString()
                                    + " дом №" + клДом.deRow.номер.ToString()
                                    + клДом.deRow.корпус
                                    + " улица " + клДом.deRow.улицы.наимен
                                    + "   " + клУслуга.deRow.наимен;
                                    ОплатаПодъезда.ShowDialog();
                                    Cursor = Cursors.Default;
                                }
                            }
                        }
                    }

                }
            }

        }

        private void заданияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            заданияForm формаЗадания = new заданияForm();
            формаЗадания.ShowDialog();

        }

        private void фильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            фильтр2 форма2 = new фильтр2();
            форма2.ShowDialog();

        }

        private void оплатыКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клСотрудник.выбран = false;
            все_кассиры выборМенеджера = new все_кассиры();
            выборМенеджера.ShowDialog();
            
            if (клСотрудник.выбран)
            {
                Cursor = Cursors.WaitCursor;
                выбор_квартиры выборКвартиры = new выбор_квартиры();
                выборКвартиры.Text = "Выберите клиента   менеджер " + клСотрудник.фио;
                выборКвартиры.ShowDialog();
            }

            Cursor = Cursors.Default;
        }

        private void простоиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_простоев списокПростоев = new список_простоев();
            списокПростоев.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void всеОплатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Cursor = Cursors.WaitCursor;
            все_оплаты всеОплаты = new все_оплаты();
            всеОплаты.Text = "Обзор всех оплат";
            всеОплаты.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void оплата1МенежерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клСотрудник.выбран = false;
            все_кассиры выборКассира = new все_кассиры();
            выборКассира.ShowDialog();
            if (клСотрудник.выбран)
            {
                Cursor = Cursors.WaitCursor;
                все1оплаты всеОплаты = new все1оплаты();
                всеОплаты.Text = "Оплаты " + клСотрудник.deRow.фио;
                всеОплаты.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void цена0ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            изменена_цена форма1 = new изменена_цена();
            форма1.ShowDialog();
        }

        private void оплатаToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void переключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    переключения1вид формаАнализ = new переключения1вид();
                    формаАнализ.Text = "Число переключений с услуги на услугу с "
                             + клПериод.дата_с.ToLongDateString()
                        + " по " + клПериод.дата_с.ToLongDateString();
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }
        }

        private void монтажникам1ВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if(клВид_услуги.выбран)
            {
                Cursor = Cursors.WaitCursor;
                монтажники1вид монтажникиВид = new монтажники1вид();
                монтажникиВид.Text = "Обзор оплат " + клВид_услуги.наимен;
                монтажникиВид.ShowDialog();
               Cursor = Cursors.Default;
            }
        }

        private void статистикаНаДатуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";

            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                Cursor = Cursors.WaitCursor;
                статистика_дата формаСтатистика = new статистика_дата();
                формаСтатистика.Text = "Статистика на " + клКалендарь.дата.Value.ToLongDateString();
                формаСтатистика.ShowDialog();
                Cursor = Cursors.Default;

            }

        }

        private void числоПодключенийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            подключено_клиентов подключеноКлиентов = new подключено_клиентов();
            подключеноКлиентов.ShowDialog();
        }

        private void домДолжникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            дом_услуга формаКвартиры = new дом_услуга();
            формаКвартиры.ShowDialog();
            Cursor = Cursors.Default;

        }

        private void повторовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    повторно44включено формаАнализ = new повторно44включено();
                    формаАнализ.Text = "Число повторных подключений клиентов отключеных за период с "
                        + клПериод.дата_с.ToLongDateString()
                        + " по " + клПериод.дата_с.ToLongDateString();
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;
                }

            }
        }

        private void заданияНаОтключенияВДомеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {

                    Cursor = Cursors.WaitCursor;
                    монтажники1дом графикМонтажникам = new монтажники1дом();
                    графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                             + " в доме № "
                                             + клДом.номер.ToString() + клДом.корпус
                                             + " по улице " + клДом.deRow.улицы.наимен;

                    графикМонтажникам.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            удаленные_оплаты удаленныеОплаты = new удаленные_оплаты();
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            удаленные_месяцы удаленныеОплаты = new удаленные_месяцы();
            удаленныеОплаты.ShowDialog();

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void всеУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_услуги ВсеУслуги = new все_услуги();
            ВсеУслуги.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void однаУслугаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                одна_услуга списокКвартир = new одна_услуга();
                списокКвартир.Text = " Подключены к " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void обзорВсеУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_услуги ВсеУслуги = new все_услуги();
            ВсеУслуги.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void обзор1УслугаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                одна_услуга списокКвартир = new одна_услуга();
                списокКвартир.Text = " Подключены к " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void платежи1ВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                Cursor = Cursors.WaitCursor;
                монтажники1вид монтажникиВид = new монтажники1вид();
                монтажникиВид.Text = "Обзор оплат " + клВид_услуги.наимен;
                монтажникиВид.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void оплаты1ВидToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                Cursor = Cursors.WaitCursor;
                монтажники1вид монтажникиВид = new монтажники1вид();
                монтажникиВид.Text = "Обзор оплат " + клВид_услуги.наимен;
                монтажникиВид.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void оплаты1УслугаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                одна_услуга списокКвартир = new одна_услуга();
                списокКвартир.Text = " Подключены к " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void оплатыВсеУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_услуги ВсеУслуги = new все_услуги();
            ВсеУслуги.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void оплаты1ВидToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                Cursor = Cursors.WaitCursor;
                монтажники1вид монтажникиВид = new монтажники1вид();
                монтажникиВид.Text = "Обзор оплат " + клВид_услуги.наимен;
                монтажникиВид.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void оплаты1УслугаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                одна_услуга списокКвартир = new одна_услуга();
                списокКвартир.Text = " Подключены к " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void всеОплатыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_услуги ВсеУслуги = new все_услуги();
            ВсеУслуги.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void оплатаЗаМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {
                    клМесяц.выбран = false;
                    выбор_месяца выборМесяца = new выбор_месяца();
                    выборМесяца.ShowDialog();
                    if (клМесяц.выбран)
                    {
                        Cursor = Cursors.WaitCursor;
//                        дом1месяц графикМонтажникам = new дом1месяц();
                        упр_компания графикМонтажникам = new  упр_компания();
                        графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                                 + " в доме № "
                                                 + клДом.номер.ToString() + клДом.корпус
                                                 + " по улице " + клДом.deRow.улицы.наимен
                                                 + " за " + клМесяц.наимен;

                        графикМонтажникам.ShowDialog();
                        Cursor = Cursors.Default;
                    }
                }
            }
            Cursor = Cursors.Default;

        }

        private void задание1Вид1ДомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {

                    Cursor = Cursors.WaitCursor;
                    дом1вид графикМонтажникам = new дом1вид()
                    {
                        Text = клВид_услуги.наимен.Trim() + " "
                                             + " в доме № "
                                             + клДом.deRow.номер.ToString() + клДом.deRow.корпус
                                             + " по улице " + клДом.deRow.улицы.наимен,
                         

                    };
                //графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                //                             + " в доме № "
                //                             + клДом.deRow.номер.ToString() + клДом.deRow.корпус
                //                             + " по улице " + клДом.deRow.улицы.наимен;

                    графикМонтажникам.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }
            Cursor = Cursors.Default;
        }

        private void задание1Услуга1ДомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клУслуга.выбран = false;
            выбор_услуги выборВида = new выбор_услуги();
            выборВида.ShowDialog();
            if (клУслуга.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {

                    Cursor = Cursors.WaitCursor;
                    дом1услуга графикМонтажникам = new дом1услуга();
                    графикМонтажникам.Text = клУслуга.наимен.Trim() + " "
                                             + " в доме № "
                                             + клДом.deRow.номер.ToString() + клДом.deRow.корпус
                                             + " по улице " + клДом.deRow.улицы.наимен;

                    графикМонтажникам.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }
            Cursor = Cursors.Default;
        }

        private void создатьРезервнуюКопиюБазыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Properties.Settings.Default.domofon14ConnectionString))
                {


                    string командаАрхив = @"BACKUP DATABASE [domofon14] TO  [домофон14] WITH NOFORMAT, INIT,  NAME = N'domofon14-Полная База данных Резервное копирование', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                    IDbCommand command = new System.Data.SqlClient.SqlCommand(командаАрхив);
                    command.Connection = conn;
                    conn.Open();
                    int результат = command.ExecuteNonQuery();
                    if (результат == -1)
                    {
                        MessageBox.Show("Записана резервная копия базы данных... ", "Архивация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Сбой записи  копии базы данных... ", "Архивация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Сбой записи " + ex.Message);
            }
            Cursor = Cursors.Default;
        }

        private void архивДомаНаБумагеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клМесяц.выбран = false;
            выбор_года ВыборГода = new выбор_года();
            ВыборГода.ShowDialog();
            if (клМесяц.выбран)
            {



                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    горизонт_дом ГоризонтДом = new горизонт_дом();
                    ГоризонтДом.Text = "Оплаты жильцов дома № " + клДом.deRow.номер.ToString().Trim()
                        + " " + клДом.deRow.корпус.Trim()
                        + " по улице  " + клДом.deRow.улицы.наимен;
                    ГоризонтДом.ShowDialog();
                    //    ГоризонтДом.Show();
                    Cursor = Cursors.Default;

                }
            }

        }

        private void архивУлицыНаБумагеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клУлица.выбран = false;
            выбор_улицы ВыборУлицы = new выбор_улицы();
            ВыборУлицы.ShowDialog();
            if (клУлица.выбран)
            {
                клУслуга.выбран = false;
                выбор_услуги ВыборУслуги = new выбор_услуги();
                ВыборУслуги.ShowDialog();
                if (клУслуга.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    платежи_улицы формаАрхив = new платежи_улицы();
                    формаАрхив.Text = "Оплачено до  за " + клУслуга.наимен + " ул. " + клУлица.наимен;
                    формаАрхив.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }

        }

        private void вид1ДомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {
                    клВид_услуги.выбран = false;
                    пометитьVуслуги ОтметитьУслуги = new пометитьVуслуги();
                    ОтметитьУслуги.ShowDialog();
                    if (клВид_услуги.выбран)
                    {
                        Cursor = Cursors.WaitCursor;
                        монтажникам_повтор графикМонтажникам = new монтажникам_повтор();
                        графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                                 + " в доме № "
                                                 + клДом.номер.ToString() + клДом.корпус
                                                 + " по улице " + клДом.deRow.улицы.наимен;

                        графикМонтажникам.ShowDialog();
                        Cursor = Cursors.Default;
                    }
                }
            }
            Cursor = Cursors.Default;

        }

        private void видУлицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клУлица.выбран = false;
                выбор_улицы ВыборУлицы = new выбор_улицы();
                ВыборУлицы.ShowDialog();
                if (клУлица.выбран)
                {
                    клВид_услуги.выбран = false;
                    отметитьVуслуги ОтметитьУслуги = new отметитьVуслуги();
                    ОтметитьУслуги.ShowDialog();
                    if (клВид_услуги.выбран)
                    {
                        клДом.выбран = false;
                        выборVдомов выборДома = new выборVдомов();
                        выборДома.Text = "Выберите дома на улице " + клУлица.наимен;
                        выборДома.ShowDialog();
                    }
                  
                }
            }

        }

        private void оплатаЗаДеньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКалендарь.дата = DateTime.Today;
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";
            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                Cursor = Cursors.WaitCursor;
                клСотрудник.выбран = false;
                //                выбор_менеджера выборКассира = new выбор_менеджера();
                все1кассиры выборКассира = new все1кассиры();
                выборКассира.ShowDialog();

                if (клСотрудник.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    день1оплаты оплатыДень = new день1оплаты() ;
                    оплатыДень.Text = "Оплаты за " + клКалендарь.дата.Value.ToLongDateString() + " менеджер " + клСотрудник.фио;
                    оплатыДень.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
            Cursor = Cursors.Default;
        }

        private void отчетЗаПериодToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клПериод.выбран = false;

            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                Cursor = Cursors.WaitCursor;
                отчет1период формаОтчет = new отчет1период();
                формаОтчет.Text = "Отчет с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString();
                формаОтчет.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void отчетЗаПериод1МенеджерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клПериод.выбран = false;

            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                клСотрудник.выбран = false;
                выбор_кассира ВыборСотрудника = new выбор_кассира();
                ВыборСотрудника.ShowDialog();
                if (клСотрудник.выбран)
                {
                    Cursor = Cursors.WaitCursor;
//                    период1кассир формаОтчет = new период1кассир();
                    выбор1реестра формаОтчет = new выбор1реестра();
                    формаОтчет.Text = "Отчет с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString()
                        + "   менеджер " + клСотрудник.фио;
                    формаОтчет.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void отчетЗаВыбранныеДниToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клПериод.выбран = false;

            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                Cursor = Cursors.WaitCursor;
                //отчет_дни формаОтчет = new отчет_дни();
                выборVреестра формаОтчет = new выборVреестра();

                формаОтчет.Text = "Отчет с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString();
                формаОтчет.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void статистикаНаДатуToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";

            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                Cursor = Cursors.WaitCursor;
                статистика_дата формаСтатистика = new статистика_дата();
                формаСтатистика.Text = "Статистика на " + клКалендарь.дата.Value.ToLongDateString();
                формаСтатистика.ShowDialog();
                Cursor = Cursors.Default;

            }
        }

        private void статистикаНаСегодняToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            статистика44 формаАнализ = new статистика44();
            формаАнализ.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void подключеноОтключеноЗаПериодToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    отключено1период формаАнализ = new отключено1период();
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;
                }

            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    отключено1период формаАнализ = new отключено1период();
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (клСервер.проверкаСоединения() == false)
            {
                MessageBox.Show("Нет соединения с сервером..");
                Close();
            }

            оплатаToolStripMenuItem.Select();
        }

        private void управляющейКомпанииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void видыОплатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            список_видов_оплат формаАнализ = new список_видов_оплат();
            формаАнализ.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void удалитьКвартирыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            выбор_жителя выборЖителя = new выбор_жителя();
            выборЖителя.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void заданиеНаОтключение1ДомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги выборВида = new выбор_вида_услуги();
            выборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран)
                {

                    Cursor = Cursors.WaitCursor;
                    монтажники1дом графикМонтажникам = new монтажники1дом();
                    графикМонтажникам.Text = клВид_услуги.наимен.Trim() + " "
                                             + " в доме № "
                                             + клДом.номер.ToString() + клДом.корпус
                                             + " по улице " + клДом.deRow.улицы.наимен;

                    графикМонтажникам.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }
            Cursor = Cursors.Default;
        }

        private void заданиеПоВидамУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран || ВыборВида.DialogResult== DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                монтажники1вид монтажникиВид = new монтажники1вид();
                монтажникиВид.Text = "Обзор оплат " + клВид_услуги.наимен;
                монтажникиВид.ShowDialog();
                //по_видам ФормаПо = new по_видам();
                //ФормаПо.Text = "Платежи за " + клВид_услуги.наимен;
                //ФормаПо.ShowDialog();
                Cursor = Cursors.Default;
            }
            Cursor = Cursors.Default;
        }

        private void статистикаНаДатуToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";

            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                Cursor = Cursors.WaitCursor;
                статистика_дата формаСтатистика = new статистика_дата();
                формаСтатистика.Text = "Статистика на " + клКалендарь.дата.Value.ToLongDateString();
                формаСтатистика.ShowDialog();
                Cursor = Cursors.Default;

            }
        }

        private void отключеноПодключеноЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клВид_услуги.выбран = false;
            выбор_вида_услуги ВыборВида = new выбор_вида_услуги();
            ВыборВида.ShowDialog();
            if (клВид_услуги.выбран)
            {
                клПериод.выбран = false;
                выбор_периода ВыборПериода = new выбор_периода();
                ВыборПериода.ShowDialog();
                if (клПериод.выбран)
                {
                    Cursor = Cursors.WaitCursor;
                    отключено1период формаАнализ = new отключено1период();
                    формаАнализ.ShowDialog();
                    Cursor = Cursors.Default;
                }

            }
        }

        private void статистикаНаСегодняToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            статистика44 формаАнализ = new статистика44();
            формаАнализ.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void реестрЗаДеньToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            клКалендарь.дата = DateTime.Today;
            клКалендарь.выбран = false;
            календарь выборДаты = new календарь();
            выборДаты.button3.Visible = false;
            выборДаты.button1.Text = "Выбор";
            выборДаты.ShowDialog();
            if (клКалендарь.выбран)
            {
                Cursor = Cursors.WaitCursor;

                клПериод.дата_с = клКалендарь.дата.Value;
                клПериод.дата_по = клКалендарь.дата.Value;
              
                выбор_реестра формаОтчет = new выбор_реестра();
                формаОтчет.Text = "Отчет за " + клПериод.дата_с.ToLongDateString() ;
                формаОтчет.ShowDialog();
             
                //клСотрудник.выбран = false;
                ////                выбор_менеджера выборКассира = new выбор_менеджера();
                //все1кассиры выборКассира = new все1кассиры();
                //выборКассира.ShowDialog();

                //if (клСотрудник.выбран)
                //{
                //    клВид_услуги.выбран = false;
                //    выбор_вида_услуги выборВидаУслуги = new выбор_вида_услуги();
                //    выборВидаУслуги.ShowDialog();
                //    if (клВид_услуги.выбран)
                //    {
                //        клВид_оплаты.выбран = false;
                //        выбор_вида_оплат выборВида = new выбор_вида_оплат();
                //        выборВида.ShowDialog();

                //        if (клВид_оплаты.выбран || выборВида.DialogResult == DialogResult.OK)
                //        {

                //            клРеестр.дата = клКалендарь.дата.Value;
                //            клРеестр.фио_менеджера = клСотрудник.deRow.фио;
                //            клРеестр.менеджер = клСотрудник.сотрудник;
                //            клРеестр.вид_оплаты = клВид_оплаты.вид_оплаты;
                //            клРеестр.наименВидаОплаты = клВид_оплаты.deRow.наимен;


                //            Cursor = Cursors.WaitCursor;
                //            реестр_услуг формаРеестр = new реестр_услуг();
                //            формаРеестр.Text = "Реестр за " + клРеестр.дата.ToLongDateString() + "  ";
                //            формаРеестр.Text += " " + клВид_услуги.наимен.Trim();
                //            формаРеестр.Text += " " + клВид_оплаты.deRow.наимен.Trim();
                //            формаРеестр.Text += " " + клСотрудник.фио.Trim();

                //            клФилиал.init();
                //            //string наименФилиала = de.филиалы
                //            //    .OrderBy(n => n.порядок)
                //            //    .First().наимен;
                //            формаРеестр.Text += " по филиалу " + клФилиал.deRow.наимен;

                //            формаРеестр.ShowDialog();
                //            Cursor = Cursors.Default;
                //        }
                //    }
                //}
            }
            Cursor = Cursors.Default;
        }

        private void отчетЗаПериодToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            клПериод.выбран = false;

            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                Cursor = Cursors.WaitCursor;
               отчет1период формаОтчет = new отчет1период();
                формаОтчет.Text = "Отчет с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString();
                формаОтчет.ShowDialog();
                Cursor = Cursors.Default;
            }

        }

        private void выборРеестраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            клПериод.выбран = false;

            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                Cursor = Cursors.WaitCursor;
                выбор_реестра формаОтчет = new выбор_реестра();
                формаОтчет.Text = "Отчет с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString();
                формаОтчет.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void числоКлиентовToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            число_договоров подключеноКлиентов = new число_договоров();
            подключеноКлиентов.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void числоПодключенийToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            подключено_клиентов подключеноКлиентов = new подключено_клиентов();
            подключеноКлиентов.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void домДолжникиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            дом_услуга формаКвартиры = new дом_услуга();
            формаКвартиры.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void платежиДомаToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            клМесяц.выбран = false;
            выбор_года ВыборГода = new выбор_года();
            ВыборГода.ShowDialog();
            if (клМесяц.выбран)
            {
                клДом.выбран = false;
                выбор_дома ВыборДома = new выбор_дома();
                ВыборДома.ShowDialog();
                if (клДом.выбран || ВыборДома.DialogResult== DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    горизонт1дом ГоризонтДом = new горизонт1дом();
                    ГоризонтДом.Text = "Оплаты жильцов дома № " + клДом.deRow.номер.ToString().Trim()
                        + " " + клДом.deRow.корпус.Trim()
                        + " по улице  " + клДом.deRow.улицы.наимен;
                    ГоризонтДом.ShowDialog();
                    Cursor = Cursors.Default;

                }
            }
        }

        private void платежиУлицыToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            клУлица.выбран = false;
            выбор_улицы ВыборУлицы = new выбор_улицы();
            ВыборУлицы.ShowDialog();
            if (клУлица.выбран || ВыборУлицы.DialogResult== DialogResult.OK)
            {
                клУслуга.выбран = false;
                выбор_услуги ВыборУслуги = new выбор_услуги();
                ВыборУслуги.ShowDialog();
                if (клУслуга.выбран || ВыборУслуги.DialogResult == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    платежи_улицы формаАрхив = new платежи_улицы();
                    формаАрхив.Text = "Оплачено до  за " + клУслуга.наимен + " ул. " + клУлица.наимен;
                    формаАрхив.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }

        }

        private void числоДговоровПоПоселкамToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            договоров_поселок договоровПоселок = new договоров_поселок();
            договоровПоселок.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void числоПодключенийПоПоселкамToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            подключений_поселок договоровПоселок = new подключений_поселок();
            договоровПоселок.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void отчетЗаПериод1МенеджерToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            клПериод.выбран = false;

            выбор_периода ВыборПериода = new выбор_периода();
            ВыборПериода.ShowDialog();
            if (клПериод.выбран)
            {
                клСотрудник.выбран = false;
                выбор_кассира ВыборСотрудника = new выбор_кассира();
                ВыборСотрудника.ShowDialog();
                if (клСотрудник.выбран || ВыборСотрудника.DialogResult== DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    период1кассир формаОтчет = new период1кассир();
                    формаОтчет.Text = "Отчет с " + клПериод.дата_с.ToLongDateString() + " по " + клПериод.дата_по.ToLongDateString()
                        + "   менеджер " + клСотрудник.фио;
                    формаОтчет.ShowDialog();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void статистикаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            число_подключений ФормаСтатистика = new число_подключений();
            ФормаСтатистика.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void подключенияКУслугамToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                подключены1услуга списокКвартир = new подключены1услуга();
                списокКвартир.Text = " Подключены к " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void всеУслугиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_услуги ВсеУслуги = new все_услуги();
            ВсеУслуги.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            клУслуга.выбран = false;
            выбор_услуги ВыборУслуги = new выбор_услуги();
            ВыборУслуги.ShowDialog();
            if (клУслуга.выбран)
            {
                Cursor = Cursors.WaitCursor;
                //      подключены1услуга списокКвартир = new подключены1услуга();
                монтажникам1услуга списокКвартир = new монтажникам1услуга();
                списокКвартир.Text = " Должники " + клУслуга.наимен;
                списокКвартир.ShowDialog();
                Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            все_услуги ВсеУслуги = new все_услуги();
            ВсеУслуги.ShowDialog();
            Cursor = Cursors.Default;
        }

        private void пробаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            проба_соединения пробаФорма = new проба_соединения();
            пробаФорма.ShowDialog();
        }

        private void пробаToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            проба_соединения пробаФорма = new проба_соединения();
            пробаФорма.ShowDialog();
        }
    }
}
