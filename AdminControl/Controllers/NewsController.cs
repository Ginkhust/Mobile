using System;
using Parse;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminControl.Models;
using System.Threading.Tasks;
using System.Web.Security;

namespace AdminControl.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NewsController : Controller
    {
        public async Task<ActionResult> NewsList()
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
                IEnumerable<ParseObject> newsList = await query.FindAsync();

                List<NewsViewModel> _newsList = new List<NewsViewModel>();

                foreach (ParseObject n in newsList)
                {
                    NewsViewModel news = new NewsViewModel();
                    news.newsId = n.ObjectId;
                    news.title = n.Get<string>("title");
                    news.content = n.Get<string>("content");
                    _newsList.Add(news);
                }
                return View(_newsList);

            }
            catch (ParseException pe)
            {
                return View();
            }
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public async Task<ActionResult> AddNews(FormCollection form)
        {
            try
            {
                ParseObject news = new ParseObject("News");

                news["title"] = form["title"].ToString();
                news["content"] = form["content"].ToString();

                // Save new news
                await news.SaveAsync();
                return RedirectToAction("NewsList");
            }
            catch (ParseException e)
            {
                return View();
            }
        }

        public async Task<ActionResult> EditNews(string id)
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
                ParseObject news = await query.GetAsync(id);

                NewsViewModel _news = new NewsViewModel();
                _news.newsId = id;
                _news.title = news.Get<string>("title");
                _news.content = news.Get<string>("content");

                return View(_news);
            }
            catch (ParseException pe)
            {
                return View();
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public async Task<ActionResult> EditNews(string id, NewsViewModel n)
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
                ParseObject news = await query.GetAsync(n.newsId);

                news["title"] = n.title;
                news["content"] = n.content;
                await news.SaveAsync();
                return RedirectToAction("NewsList");

            }
            catch (ParseException pe)
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteNews(string nid)
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("News");
                ParseObject news = await query.GetAsync(nid);

                await news.DeleteAsync();
                return RedirectToAction("NewsList");
            }
            catch (ParseException pe)
            {
                ViewBag.pe = pe.Message;
                return RedirectToAction("NewsList");
            }
        }
    }
}