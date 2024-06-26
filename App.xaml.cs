using jtoapantaS5.Utils;

namespace jtoapantaS5
{
    public partial class App : Application
    {

        public static PersonRepository personrepo {  get; set; }
        public App(PersonRepository person)
        {
            InitializeComponent();

            MainPage = new Views.vHome();
            personrepo = person;
        }
    }
}
