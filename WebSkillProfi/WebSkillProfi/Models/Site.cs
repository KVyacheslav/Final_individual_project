using Newtonsoft.Json.Linq;

namespace WebSkillProfi.Models
{
    public static class Site
    {
        // HOME
        public static string HomeHeroTitle { get; set; } = "-КОНСАЛТИНГ\n\t\tБЕЗ РЕГИСТРАЦИИ И СМС";
        public static string HomeHeroButton { get; set; } = "ОСТАВИТЬ ЗАЯВКУ";
        public static string HomeFormTitle { get; set; } = "Оставить заявку или задать вопрос";


        //REQUESTS
        public static List<Request> Requests { get; set; }

        // PROJECTS
        public static List<Project> Projects { get; set; }


        // SERVICES
        public static List<Service> Services { get; set; }


        // Blog
        public static List<Blog> Blogs { get; set; }


        //CONTACTS
        public static List<Contact> Contacts { get; set; }



        public static void SaveValuesToJson()
        {
            JObject site = new JObject();

            JObject home = new JObject();
            home["home_hero_title"] = "-КОНСАЛТИНГ\n\t\tБЕЗ РЕГИСТРАЦИИ И СМС";
            home["home_hero_button"] = "ОСТАВИТЬ ЗАЯВКУ";
            home["home_form_title"] = "Оставить заявку или задать вопрос";
            site["home"] = home;

            File.WriteAllText("site.json", site.ToString());
        }

        public static void LoadValuesFromJson()
        {
            JObject site = JObject.Parse(File.ReadAllText("site.json"));
            JObject home = JObject.Parse(site["home"].ToString());

            HomeFormTitle = home["home_hero_title"].ToString();
            HomeHeroButton = home["home_hero_button"].ToString();
            HomeFormTitle = home["home_form_title"].ToString();
        }
    }
}
