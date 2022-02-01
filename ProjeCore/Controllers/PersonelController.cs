using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjeCore.DAL;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class PersonelController : Controller
    {
        private readonly Context _context;
        public PersonelController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.Personels.Include(x=>x.Birim).ToList();
            return View(degerler);
        }
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in _context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BrimAd,
                                                 Value = x.BrimId.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = _context.Birims.Where(x => x.BrimId == p.Birim.BrimId).FirstOrDefault();
            p.Birim = per;
            _context.Personels.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            var deg = _context.Personels.Find(id);
            _context.Personels.Remove(deg);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
