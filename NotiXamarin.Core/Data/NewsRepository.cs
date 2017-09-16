using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NotiXamarin.Core.Models;

namespace NotiXamarin.Core.Data
{
    internal class NewsRepository
    {
        private List<News> _news;

        public NewsRepository()
        {
            _news = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "Noticia desde el repositorio",
                    Body = "Xamarin es una compañía de software estadounidense, propiedad de Microsoft y con sede principal en San Francisco (California), fundada en mayo de 2011 por Nat Friedman y Miguel de Icaza (que iniciaron el Proyecto Mono)",
                    ImageName = "noticia1.png"
                },
                new News()
                {
                    Id = 2,
                    Title = "ASP.NET MVC 5",
                    Body = "ASP.NET es un entorno para aplicaciones web desarrollado y comercializado por Microsoft. Es usado por programadores y diseñadores para construir sitios web dinámicos, aplicaciones web y servicios web XML. Apareció en enero de 2002 con la versión 1.0 del .NET Framework, y es la tecnología sucesora de la tecnología Active Server Pages (ASP). ASP.NET está construido sobre el Common Language Runtime, permitiendo a los programadores escribir código ASP.NET usando cualquier lenguaje admitido por el .NET Framework.",
                    ImageName = "noticia2.png"
                },
                new News()
                {
                    Id = 3,
                    Title = "AngularJS",
                    Body = "AngularJS (comúnmente llamado Angular.js o AngularJS 1), es un framework de JavaScript de código abierto, mantenido por Google, que se utiliza para crear y mantener aplicaciones web de una sola página. Su objetivo es aumentar las aplicaciones basadas en navegador con capacidad de Modelo Vista Controlador (MVC), en un esfuerzo para hacer que el desarrollo y las pruebas sean más fáciles. La biblioteca lee el HTML que contiene atributos de las etiquetas personalizadas adicionales, entonces obedece a las directivas de los atributos personalizados, y une las piezas de entrada o salida de la página a un modelo representado por las variables estándar de JavaScript. Los valores de las variables de JavaScript se pueden configurar manualmente, o recuperados de los recursos JSON estáticos o dinámicos.",
                    ImageName = "noticia3.png"


                }
            };
        }

        public List<News> GetNews()
        {
            return _news;
        }

        public News GetNewsById(int Id)
        {
            return _news.FirstOrDefault(x => x.Id == Id);
        }
    }
}