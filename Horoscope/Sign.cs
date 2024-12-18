using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Horoscope.Forms;
using static System.Net.WebRequestMethods;

namespace Horoscope
{
    public partial class Sign : Form
    {
        public Sign()
        {
            InitializeComponent();
            DateTimePicker dateTimePicker1 = new DateTimePicker();
            //Отображения сегоднейшей даты
            Dataonline.Text += " ";
            Dataonline.Text += Convert.ToString(dateTimePicker1.Value);
        }
        //Создания полей со свойствами
        public string Aries {  get; set; }
        public string Taurus {  get; set; }
        public string Twins {  get; set; }
        public string Cancer {  get; set; }
        public string Leo {  get; set; }
        public string Maid {  get; set; }
        public string Scales {  get; set; }
        public string Scorpio {  get; set; }
        public string Sagittarius {  get; set; }
        public string Capricorn {  get; set; }
        public string Aquarius {  get; set; }
        public string Pisces {  get; set; }
        public int A;
        public bool PressButton;
        private void button1_Click(object sender, EventArgs e)
        {
            //Отметка о том что кнопка нажималась при выбранном знаке зодиака
            PressButton = true;
            A = ChooseSign.SelectedIndex;
            //Выполняем функции взависимости от выбранного знака зодиака
            switch (A)
            {
                case 0:
                    Aries = HoroscopeText("https://horo.mail.ru/prediction/aries/today/");      
                    SignAries signAries = new SignAries(Aries);
                    signAries.ShowDialog();
                    break;
                case 1:
                     Taurus = HoroscopeText("https://horo.mail.ru/prediction/taurus/today/");
                    SignTaurus signTaurus = new SignTaurus(Taurus);
                    signTaurus.ShowDialog();
                    break;
                case 2:
                     Twins = HoroscopeText("https://horo.mail.ru/prediction/gemini/today/");
                    SignTwins signTwins = new SignTwins(Twins);
                    signTwins.ShowDialog();
                    break;
                case 3:
                     Cancer = HoroscopeText("https://horo.mail.ru/prediction/cancer/today/");
                    SignCancer signCancer = new SignCancer(Cancer);
                    signCancer.ShowDialog();
                    break;
                case 4:
                     Leo = HoroscopeText("https://horo.mail.ru/prediction/leo/today/");
                    SignLeo signLeo = new SignLeo(Leo);
                    signLeo.ShowDialog();
                    break;
                case 5:
                     Maid = HoroscopeText("https://horo.mail.ru/prediction/virgo/today/");
                    SignMaid signMaid = new SignMaid(Maid);
                    signMaid.ShowDialog();
                    break;
                case 6:
                     Scales = HoroscopeText("https://horo.mail.ru/prediction/libra/today/");
                    SignScales signScales = new SignScales(Scales);
                    signScales.ShowDialog();
                    break;
                case 7:
                     Scorpio = HoroscopeText("https://horo.mail.ru/prediction/scorpio/today/");
                    SignScorpio signScorpio = new SignScorpio(Scorpio);
                    signScorpio.ShowDialog();
                    break;
                case 8:
                     Sagittarius = HoroscopeText("https://horo.mail.ru/prediction/sagittarius/today/");
                    SignSagittarius signSagittarius = new SignSagittarius(Sagittarius);
                    signSagittarius.ShowDialog();
                    break;
                case 9:
                     Capricorn = HoroscopeText("https://horo.mail.ru/prediction/capricorn/today/");
                    SignCapricorn signCapricorn = new SignCapricorn(Capricorn);
                    signCapricorn.ShowDialog();
                    break;
                case 10:
                     Aquarius = HoroscopeText("https://horo.mail.ru/prediction/aquarius/today/");
                    SignAquarius signAquarius = new SignAquarius(Aquarius);
                    signAquarius.ShowDialog();
                    break;
                case 11:
                     Pisces = HoroscopeText("https://horo.mail.ru/prediction/pisces/today/");
                    SignPisces signPisces = new SignPisces(Pisces);
                    signPisces.ShowDialog();
                    break;

            }
        }

        private void ChooseSign_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Блокировка кнопки при не выбранном знаке зодиака
            ButtStart.Enabled = true;
            //При смене знака зодиака кнопка ещё не нажалось
            PressButton = false;
        }
        private string HoroscopeText(string Http)
        {
            //Удаления не нужных символов из текста
            string[] deleteSymbol = { "div", "/div","</>","/main","<>", "< article-item-type=\"html\" class=\"b6a5d4949c e45a4c1552\">","< class=\"","nbsp;" };
            //Строчка начало откуда читаеться код
            string website = "<div article-item-type=\"html\" class=\"b6a5d4949c e45a4c1552\">";
            //Создания чтения текста
            WebRequest request = WebRequest.Create(@""+Http);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string str = sr.ReadToEnd();
            //Обрезания начало кода от основного текста
            str = str.Substring(str.IndexOf(website)+website.Length);
            str = str.Remove(0, 8);
            //Удаляеться после заданной строчке
            str = str.Remove(str.IndexOf("b1b7b75f6a"));
            //Замена тегов на специальные символы
            str = str.Replace("<p>", "\t");
            str = str.Replace("</p>", "\n");
            str = str.Replace(".", ".\n");
            foreach(string st in deleteSymbol)
            {
                str = str.Replace(st, "");
            }
            return str;
        }
        private void Sign_Load(object sender, EventArgs e)
        {

        }

        private void датыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создаю экземпляр формы DateSign
            DateSign dateSign = new DateSign();
            //Вывожу её на экран
            dateSign.ShowDialog();
        }
        //Показываю информацию о выбранном знаке в контекстном меню
        private void овенToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Огонь\r\n\r\n• Управляющая планета: Марс\r\n\r\n▎Положительные качества:\r\n\r\n• Энергия и активность\r\n\r\n• Уверенность и лидерские качества\r\n\r\n• Инициативность\r\n\r\n▎Отрицательные качества:\r\n\r\n• Импульсивность\r\n\r\n• Упрямство\r\n\r\n• Конфликтность\r\n\r\n▎В отношениях:\r\n\r\n• Страстные и преданные, требуют внимания и свободы.\r\n\r\n▎В карьере:\r\n\r\n• Успешные лидеры и предприниматели, любят активные роли.", "Овен");
        }

        private void телецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Земля\r\n\r\n• Управляющая планета: Венера\r\n\r\n▎Положительные качества: \r\n\r\n• Практичность и надежность \r\n\r\n• Упорство и настойчивость \r\n\r\n• Чувствительность к красоте и искусству \r\n\r\n▎Отрицательные качества: \r\n\r\n• Упрямство \r\n\r\n• Медлительность \r\n\r\n• Материализм \r\n\r\n▎В отношениях: \r\n\r\n• Верные и преданные партнеры, ценят стабильность и комфорт, стремятся к эмоциональной безопасности. \r\n\r\n▎В карьере: \r\n\r\n• Успешные работники, предпочитают стабильные и практичные роли, могут быть отличными финансистами и менеджерами. ", "Телец");
        }

        private void близнецыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Воздух\r\n\r\n• Управляющая планета: Меркурий\r\n\r\n▎Положительные качества:\r\n\r\n• Общительность и дружелюбие\r\n\r\n• Умение адаптироваться и учиться\r\n\r\n• Интеллектуальность и креативность\r\n\r\n▎Отрицательные качества:\r\n\r\n• Непостоянство\r\n\r\n• Поверхностность\r\n\r\n• Склонность к излишнему анализу\r\n\r\n▎В отношениях:\r\n\r\n• Любят разнообразие и общение, ценят свободу и независимость, могут быть игривыми и романтичными.\r\n\r\n▎В карьере:\r\n\r\n• Успешные коммуникаторы и новаторы, могут excel в сферах, требующих креативности и гибкости, таких как маркетинг, журналистика и продажи.", "Близнецы");
        }

        private void ракToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Вода\r\n\r\n• Управляющая планета: Луна\r\n\r\n▎Положительные качества:\r\n\r\n• Чувствительность и эмпатия\r\n\r\n• Заботливость и поддержка\r\n\r\n• Интуитивность и креативность\r\n\r\n▎Отрицательные качества:\r\n\r\n• Излишняя чувствительность\r\n\r\n• Настороженность и замкнутость\r\n\r\n• Склонность к переменам настроения\r\n\r\n▎В отношениях:\r\n\r\n• Очень преданные и заботливые партнеры, ценят эмоциональную связь и безопасность, могут быть ранимыми.\r\n\r\n▎В карьере:\r\n\r\n• Успешные в профессиях, связанных с заботой о других, таких как психология, медицина или социальная работа. Часто проявляют креативность в искусстве и дизайне.\r\n", "Рак");
        }

        private void левToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Огонь\r\n\r\n• Управляющая планета: Солнце\r\n\r\n▎Положительные качества:\r\n\r\n• Энергия и активность\r\n\r\n• Уверенность и лидерские качества\r\n\r\n• Щедрость и благородство\r\n\r\n▎Отрицательные качества:\r\n\r\n• Импульсивность\r\n\r\n• Упрямство\r\n\r\n• Конфликтность\r\n\r\n▎В отношениях:\r\n\r\n• Страстные и преданные партнеры, требуют внимания и восхищения, ценят лояльность и преданность.\r\n\r\n▎В карьере:\r\n\r\n• Успешные лидеры и предприниматели, любят активные роли, часто стремятся к признанию и успеху. Отличаются креативностью и способностью вдохновлять других.", "Лев");
        }

        private void деваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Земля\r\n\r\n• Управляющая планета: Меркурий\r\n\r\n▎Положительные качества:\r\n\r\n• Практичность и реализм\r\n\r\n• Внимание к деталям\r\n\r\n• Ответственность и надежность\r\n\r\n▎Отрицательные качества:\r\n\r\n• Склонность к критике\r\n\r\n• Перфекционизм\r\n\r\n• Излишняя самокритичность\r\n\r\n▎В отношениях:\r\n\r\n• Лояльные и заботливые партнеры, ценят стабильность и доверие, предпочитают гармонию и порядок.\r\n\r\n▎В карьере:\r\n\r\n• Отличные организаторы и аналитики, способны решать сложные задачи, часто стремятся к совершенству и эффективности в работе.", "Дева");
        }

        private void весыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Воздух\r\n\r\n• Управляющая планета: Венера\r\n\r\n▎Положительные качества:\r\n\r\n• Чувство справедливости\r\n\r\n• Обаяние и дипломатичность\r\n\r\n• Умение находить общий язык с людьми\r\n\r\n▎Отрицательные качества:\r\n\r\n• Нерешительность\r\n\r\n• Склонность к избеганию конфликтов\r\n\r\n• Поверхностность в некоторых вопросах\r\n\r\n▎В отношениях:\r\n\r\n• Стремятся к гармонии и балансу, ценят партнерство и компромиссы, романтичные и заботливые.\r\n\r\n▎В карьере:\r\n\r\n• Отличные посредники и переговорщики, могут успешно работать в сферах искусства, права и общественных отношений, любят сотрудничество и командную работу.", "Весы");
        }

        private void скорпионToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Вода\r\n\r\n• Управляющая планета: Плутон (в традиционной астрологии также Марс)\r\n\r\n▎Положительные качества:\r\n\r\n• Глубокие эмоции и интуиция\r\n\r\n• Стойкость и решительность\r\n\r\n• Способность к трансформации и восстановлению\r\n\r\n▎Отрицательные качества:\r\n\r\n• Тайные и скрытные\r\n\r\n• Одержимость и ревность\r\n\r\n• Склонность к манипуляциям\r\n\r\n▎В отношениях:\r\n\r\n• Страстные и преданные партнеры, ценят глубину и искренность, могут быть очень требовательными к своему партнеру.\r\n\r\n▎В карьере:\r\n\r\n• Успешные исследователи, психологи и предприниматели, обладают выдающимися аналитическими способностями и умением справляться с кризисами.", "Скорпион");
        }

        private void стрелецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Огонь\r\n\r\n• Управляющая планета: Юпитер\r\n\r\n▎Положительные качества:\r\n\r\n• Оптимизм и жизнерадостность\r\n\r\n• Любовь к приключениям и путешествиям\r\n\r\n• Щедрость и открытость\r\n\r\n▎Отрицательные качества:\r\n\r\n• Непостоянство\r\n\r\n• Необдуманность\r\n\r\n• Склонность к чрезмерной прямоте\r\n\r\n▎В отношениях:\r\n\r\n• Свободолюбивые и искренние, ценят независимость и разнообразие.\r\n\r\n▎В карьере:\r\n\r\n• Успешные преподаватели, путешественники и исследователи, любят делиться знаниями и опытом.", "Стрелец");
        }

        private void козерогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Земля\r\n\r\n• Управляющая планета: Сатурн\r\n\r\n▎Положительные качества:\r\n\r\n• Амбициозность и целеустремленность\r\n\r\n• Ответственность и надежность\r\n\r\n• Практичность и организованность\r\n\r\n▎Отрицательные качества:\r\n\r\n• Пессимизм\r\n\r\n• Чрезмерная серьезность\r\n\r\n• Склонность к упрямству\r\n\r\n▎В отношениях:\r\n\r\n• Преданные и стабильные партнеры, ценят долгосрочные отношения и безопасность.\r\n\r\n▎В карьере:\r\n\r\n• Успешные менеджеры, финансисты и организаторы, обладают выдающимися лидерскими качествами и стратегическим мышлением.", "Козерог");
        }

        private void водолейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Воздух\r\n\r\n• Управляющая планета: Уран (в традиционной астрологии также Сатурн)\r\n\r\n▎Положительные качества:\r\n\r\n• Оригинальность и креативность\r\n\r\n• Доброта и гуманизм\r\n\r\n• Независимость и открытость к новому\r\n\r\n▎Отрицательные качества:\r\n\r\n• Эксцентричность\r\n\r\n• Непостоянство\r\n\r\n• Склонность к дистанцированию\r\n\r\n▎В отношениях:\r\n\r\n• Свободные и независимые, ценят дружбу и интеллектуальную связь.\r\n\r\n▎В карьере:\r\n\r\n• Успешные инноваторы, ученые и социальные работники, любят работать в команде и вносить изменения.", "Водолей");
        }

        private void рыбыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("• Стихия: Вода\r\n\r\n• Управляющая планета: Нептун (в традиционной астрологии также Юпитер)\r\n\r\n▎Положительные качества:\r\n\r\n• Чувствительность и эмпатия\r\n\r\n• Творческий подход и воображение\r\n\r\n• Способность к самопожертвованию\r\n\r\n▎Отрицательные качества:\r\n\r\n• Избегание реальности\r\n\r\n• Склонность к самообману\r\n\r\n• Нерешительность\r\n\r\n▎В отношениях:\r\n\r\n• Романтичные и заботливые партнеры, ищут глубокую эмоциональную связь.\r\n\r\n▎В карьере:\r\n\r\n• Успешные художники, музыканты и психологи, обладают выдающейся интуицией и способностью понимать других.", "Рыбы");
        }
        private void сохранитьВToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Проверяю на нажатость кнопки при выбранном знаке задиака
            if (PressButton == true)
            {
                //Даю переменной индекс выбранного знака задиака
                int a = ChooseSign.SelectedIndex;
                //Создаю диалоговое окно которое сохраняет файл 
                SaveFileDialog sfd = new SaveFileDialog();
                //Даю заголовок
                sfd.Title = "Save to";
                //Ставлю допустимый сохраняемый формат
                sfd.Filter = "Text Files (*.txt)| *.txt";
                //Сохраняю файл с текстом взависимости от индекса выбранного знака зодиака
                switch (a)
                {
                    case 0:
                        //Проверка на нажатие кнопки сохранить
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Aries);
                        }
                        else
                        {
                            //Возращаюсь назад
                            return;
                        }
                        //Команда для выхода из свитча
                        break;
                    //Проделываю всё так же
                    case 1:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Taurus);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 2:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Twins);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 3:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Cancer);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 4:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Leo);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 5:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Maid);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 6:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Scales);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 7:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Scorpio);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 8:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName,Sagittarius);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 9:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Capricorn);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 10:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Aquarius);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    case 11:
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string fileName = sfd.FileName;
                            System.IO.File.WriteAllText(fileName, Pisces);
                        }
                        else
                        {
                            return;
                        }
                        break;
                }
            }
            else
            {
                //Выдаю ошибку потому что кнопка не нажималось при выбранном знаке зодиака
                MessageBox.Show("Сначало посмотрите гороскоп знака задиака,которого вы только что выбрали", "Ошибка", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
    }
}
