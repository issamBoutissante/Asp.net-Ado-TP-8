using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Asp.net_MVC_TP_8.Controllers
{
    public class ArticlesController : Controller
    {
        string conString = @"data source=.\SQLEXPRESS;database=GestionArticles;Integrated Security=true;";
        // GET: Articles
        public ActionResult Index()
        {
            return View(GetArticles());
        }
        public List<Article> GetArticles()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlDataReader reader;
                reader = new SqlCommand("select * from Article;", connection).ExecuteReader();
                List<Article> articles = new List<Article>();
                while (reader.Read())
                {
                    articles.Add(new Article()
                    {
                        Num_Art = (int)reader["Num_Art"],
                        Desig_Art = reader["Desig_Art"].ToString(),
                        PU_Art = (decimal)reader["PU_Art"],
                        QttEnStock = (int)reader["QttEnStock"],
                        SeuilMin = (int)reader["seuilMin"],
                        SeuilMax = (int)reader["seuilMax"]
                    });
                }
                return articles;
            }
        }
        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        public ActionResult Create(Article article)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    new SqlCommand($"exec InsertArticle '{article.Desig_Art}',{article.PU_Art},{article.QttEnStock},{article.SeuilMin},{article.SeuilMax}",connection).ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int numArt)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlDataReader reader=new SqlCommand($"select * from Article where num_Art={numArt}",connection).ExecuteReader();
                reader.Read();
                return View(new Article()
                {
                    Num_Art = (int)reader["Num_Art"],
                    Desig_Art = reader["Desig_Art"].ToString(),
                    PU_Art = (decimal)reader["PU_Art"],
                    QttEnStock = (int)reader["QttEnStock"],
                    SeuilMin = (int)reader["seuilMin"],
                    SeuilMax = (int)reader["seuilMax"]
                });
            }
        }

        // POST: Articles/Edit/5
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            try
            {  
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    
                    connection.Open();
                    new SqlCommand($"exec UpdateArticle '{article.Desig_Art}',{article.PU_Art},{article.QttEnStock},{article.SeuilMin},{article.SeuilMax},{article.Num_Art}", connection).ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //b-	 Afficher la Quantité en stocke d’un article donnée 
        public ActionResult AfficherQtt(int numArt)
        {
            return View();
        }

        //c-	En donnant la quantité pour un article, calculer le montant à payer
        public ActionResult CalculerMontant(int numArt)
        {
            return View();
        }

        //d-	Afficher le seuil Min et le seuil Max pour un article donné
        public ActionResult AfficherLeSeuil(int numArt)
        {
            return View();
        }
    }
}
