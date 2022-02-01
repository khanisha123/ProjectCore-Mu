using Microsoft.AspNetCore.Mvc;
using ProjeCore.DAL;
using ProjeCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Controllers
{
    public class BirimController : Controller
    {
        private readonly Context _context;
        public BirimController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var deyerler = _context.Birims.ToList();
            return View(deyerler);
        }
        public IActionResult YeniBirim()
        {

            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {

            _context.Birims.Add(b);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult BirimSil(int Id)
        {
            var dbContext = _context.Birims.Find(Id);
            _context.Birims.Remove(dbContext);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult BirimGetir(int Id)
        {
            var BirimGetir = _context.Birims.Find(Id);
            return View(BirimGetir);

        }
        [HttpPost]
        [ActionName("BirimGetir")]
        public IActionResult DepartmanGuncelle(int id, Birim b)
        {
            var findId = _context.Birims.Find(id);
            findId.BrimAd = b.BrimAd;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimDetaylar(int id)
        {
            var p = _context.Personels.Where(x=> x.BirimId==id).ToList();
            
            return View(p);
        }
    }
}
