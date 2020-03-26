using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Data.Models;

namespace MyShop.Data
{
    public class DBObjects
    {
        //заполнение бд дефолтными значениями, если она пустая
        public static void Initial(AppDBContent appDBContent)
        {
            if (!appDBContent.img.Any())
            {
                appDBContent.img.AddRange(imgs.Select(c => c.Value));
            }
            if (!appDBContent.category.Any())
            {
                appDBContent.category.AddRange(categories.Select(c => c.Value));
            }
            if (!appDBContent.item.Any())
            {
                appDBContent.item.AddRange(items.Select(i => i.Value));
            }
            if (!appDBContent.role.Any())
            {
                appDBContent.role.AddRange(roles.Select(i => i.Value));
            }
            if (!appDBContent.user.Any())
            {
                appDBContent.user.AddRange(users.Select(i => i.Value));
            }
            appDBContent.SaveChanges();
        }

        //методы изображений
        private static Dictionary<string, Img> img;
        public static Dictionary<string, Img> imgs
        {
            get
            {
                if (img == null)
                {
                    var list = new Img[]
                    {
                        new Img
                        {
                            name = "Эмаль ПФ-266 \"Proremontt\"",
                            path = "/img/emal-pf-266-proremontt.jpg"
                        },
                        new Img
                        {
                            name = "Эмаль ПФ-266 \"Май\"",
                            path = "/img/emal-pf-266-may.jpg"
                        },
                        new Img
                        {
                            name = "Эмаль ПФ-115 \"Proremontt\"",
                            path = "/img/emal-pf-155-proremontt.jpg"
                        },
                        new Img
                        {
                            name = "Эмаль ПФ-115",
                            path = "/img/EMAL-PF-115.png"
                        },
                        new Img
                        {
                            name = "Краска(эмаль) АК-511",
                            path = "/img/kraska-ak-511.jpg"
                        },
                        new Img
                        {
                            name = "Краска БТ-177",
                            path = "/img/emal-bt-177.jpg"
                        }
                    };
                    img = new Dictionary<string, Img>();
                    foreach (Img el in list)
                    {
                        img.Add(el.name, el);
                    }
                }
                return img;
            }
        }

        //методы категории
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { name = "Прочее" },
                        new Category { name = "Эмали" },
                        new Category { name = "Краски" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category el in list)
                    {
                        category.Add(el.name, el);
                    }
                }
                return category;
            }
        }

        //методы позиции
        private static Dictionary<string, Item> item;
        public static Dictionary<string, Item> items
        {
            get
            {
                if (item == null)
                {
                    var list = new Item[]
                    {
                        new Item
                        {
                            name = "Эмаль ПФ-266 \"Proremontt\"",
                            desc = "Эмаль ПФ-266 для пола на основе алкидного лака, как суспензия пигментов и добавок в пентафталевом лаке. К нему добавляются сиккативы, модифицирующие добавки и растворители. Благодаря разнообразным добавкам, обеспечиваются защитные и декоративные свойства. Предназначено средство для окрашивания поверхностей из металла или дерева.",
                            price = 249,
                            uom = "1.9 кг",
                            favourite = true,
                            available = true,
                            category = categories["Эмали"],
                            img = imgs["Эмаль ПФ-266 \"Proremontt\""]
                        },
                        new Item
                        {
                            name = "Эмаль ПФ-266 \"Май\"",
                            desc = "Эмаль ПФ-266 для пола из дерева и ДВП. Устойчива к истиранию, действию воды и моющих средств.Высыхание каждого слоя эмали при температуре (20±2)0С – 24 часа, до готовности кэксплуатации – 48 часов.Расход эмали на однослойное покрытие – в зависимости от подготовки и впитывающей способности поверхности – 1 кг на 5 -7м2.",
                            price = 275,
                            uom = "1.9 кг",
                            favourite = false,
                            available = true,
                            category = categories["Эмали"],
                            img = imgs["Эмаль ПФ-266 \"Май\""]
                        },
                        new Item
                        {
                            name = "Эмаль ПФ-115 \"Proremontt\"",
                            desc = "Применяется для окраски оконных рам, подоконников, дверей, батарей, различных деревянных и металлических предметов. Устойчива к действию воды, атмосферных осадков и растворов моющих средств, гипсокартона в хозяйственных и жилых помещениях.",
                            price = 238,
                            uom = "1.9 кг",
                            favourite = true,
                            available = true,
                            category = categories["Эмали"],
                            img = imgs["Эмаль ПФ-115 \"Proremontt\""]
                        },
                        new Item
                        {
                            name = "Эмаль ПФ-115",
                            desc = "Состав эмали пф-115 был разработан специально для обеспечения качественных технических характеристик при его использовании. Получившийся при нанесении на поверхность слой материала, выступает в роли защитного барьера от различных вредных воздействий. Для достижения максимального эффекта слой эмали должен полностью высохнуть. Эмаль пф-115 также помогает защитить обрабатываемые им изделия от больших перепадов температуры.",
                            price = 1875,
                            favourite = false,
                            available = true,
                            category = categories["Эмали"],
                            img = imgs["Эмаль ПФ-115"]
                        },
                        new Item
                        {
                            name = "Краска(эмаль) АК-511",
                            desc = "Краска АК-511 предназначена для нанесения разметки на асфальтобетонных и цементобетонных автодорогах. Представляющая собой акриловый сополимер, в который добавлены пигменты, модифицирующие добавки и другие наполнители. В состав входят органические растворители.",
                            price = 2725,
                            uom = "25кг",
                            favourite = true,
                            available = true,
                            category = categories["Краски"],
                            img = imgs["Краска(эмаль) АК-511"]
                        },
                        new Item
                        {
                            name = "Краска БТ-177",
                            desc = "Краска БТ-177 («серебрянка») предназначена для защиты и декоративной обработки поверхностей металлических, деревянных, бетонных конструкций и изделий, эксплуатирующихся в открытой атмосфере.",
                            price = 3100,
                            uom = "20кг",
                            favourite = false,
                            available = true,
                            category = categories["Краски"],
                            img = imgs["Краска БТ-177"]
                        }
                    };
                    item = new Dictionary<string, Item>();
                    foreach (Item el in list)
                    {
                        item.Add(el.name, el);
                    }
                }
                return item;
            }
        }

        //методы роль
        private static Dictionary<string, Role> role;
        public static Dictionary<string, Role> roles
        {
            get
            {
                if (role == null)
                {
                    var list = new Role[]
                    {
                        new Role { name = "Администратор" }
                    };
                    role = new Dictionary<string, Role>();
                    foreach (Role el in list)
                    {
                        role.Add(el.name, el);
                    }
                }
                return role;
            }
        }

        //методы позиции
        private static Dictionary<string, User> user;
        public static Dictionary<string, User> users
        {
            get
            {
                if (user == null)
                {
                    var list = new User[]
                    {
                        new User
                        {
                            name = "admin",
                            password = "A11adingo",
                            role = roles["Администратор"]
                        }
                    };
                    user = new Dictionary<string, User>();
                    foreach (User el in list)
                    {
                        user.Add(el.name, el);
                    }
                }
                return user;
            }
        }
    }
}
