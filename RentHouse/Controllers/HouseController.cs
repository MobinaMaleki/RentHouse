using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Models;
using RentHouse.Repository;
using RentHouse.Repository.Base;

namespace RentHouse.Controllers
{
    [Route("House")]
    public class HouseController : Controller
    {
        private readonly IHouseRepository _houseRepository;
        private readonly ILandOwnerRepository _landOwnerRepository;


        public HouseController(IHouseRepository houseRepository, ILandOwnerRepository landOwnerRepository)
        {
            _houseRepository = houseRepository;
            _landOwnerRepository = landOwnerRepository;

        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lstHouse = await _houseRepository.GetAll();

            ViewBag.LstHouse =await ConvertAllHouseToList(lstHouse);
            return View();
        }
        private async Task<string> ConvertAllHouseToList(List<House> LstHouse)
        {
            string _situation = "";
            string str = string.Empty;

            foreach (var item in LstHouse)
            {
                if (item.situation == 0)
                {
                    _situation = "شمالی";
                }
                else
                {
                    _situation = "جنوبی";
                }

                var OwnerName = await _landOwnerRepository.GetById(item.OwnerID);



                str += string.Format("<tr>"
                                  + "<td>{0}</td>"
                                  + "<td>{1}</td>"
                                  + "<td>{2}</td>"
                                   + "<td>{3}</td>"
                                   + "<td>{5}</td>"
                                  + "<td><a href='/House/UpdateById?ID={4}'>ویرایش</a></td>"
                                  + "<td><a href='/House/DeleteById?ID={4}'>حذف</a></td>"
                                  + "</tr>", item.Name, _situation, item.HouseArea, item.Address, item.Id, OwnerName.Name + " " + OwnerName.Family);


            }
            return str;
        }

        public async Task<List<LandOwner>> GetLandOwner()
        {
            return await _landOwnerRepository.GetAll();
        }

        [HttpGet]
        [Route("ShowById")]
        public async Task<IActionResult> GetById(int id)
        {
            ViewBag.HouseModel = await _houseRepository.GetById(id);
            return View();
        }
        [HttpGet]
        [Route("InsertHouse")]
        public async Task<IActionResult> Insert()
        {
            var AllOwner = await _landOwnerRepository.GetAll();

            ViewBag.Owner = GetAllLandOwnerSelection(AllOwner);

            ViewBag.situation = SituationSelection(Situation.Northern);

            return View();

        }

        private string GetAllLandOwnerSelection(List<LandOwner> AllOwner)
        {
            string strowner = "";
            foreach (var item in AllOwner)
            {
                strowner += string.Format("<Option Value={0} >{1}</Option>", item.OwnerID, item.Name + " " + item.Family);
            }
            return strowner;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Add(int Owner, string name, string Area, string Address, Situation _situation)
        {
            House _house = new House() { OwnerID=Owner,Name = name, HouseArea = Area, situation = _situation,Address=Address };

            await _houseRepository.Add(_house);
            await _houseRepository.SaveChangesAsync();

            return RedirectToAction("ShowAll");
        }
        private async Task<string> LandOwnerSelection(LandOwner landOwners)
        {
            var AllOwner = await _landOwnerRepository.GetAll();
            string strowner = "";
            foreach (var item in AllOwner)
            {
                if (item.OwnerID == landOwners.OwnerID)
                {
                    strowner += string.Format("<Option Value={0} selected >{1}</Option>", item.OwnerID, item.Name + " " + item.Family);
                }
                else
                {
                    strowner += string.Format("<Option Value={0} >{1}</Option>", item.OwnerID, item.Name + " " + item.Family);
                }
            }
            return strowner;
        }
        private string SituationSelection(Situation situation)
        {
            string Result = string.Empty;
            if (situation == Situation.Northern)
            {
                Result = "<Option Value='0' selected >شمالی</Option><Option Value='1'>جنوبی</Option>";
            }
            else
            {
                Result = "<Option Value='0' >شمالی</Option><Option Value='1' selected >جنوبی</Option>";

            }
            return Result;

        }

        [Route("DeleteById")]
        public async Task<IActionResult> Delete(int id)
        {
            await _houseRepository.RemoveById(id);
            await _houseRepository.SaveChangesAsync();
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        [Route("UpdateById")]

        public async Task<IActionResult> UpdateById(int id)
        {

            var House = await _houseRepository.GetById(id);
            var owner = await _landOwnerRepository.GetById(House.OwnerID);

            ViewBag.Owner = await LandOwnerSelection(owner);
            ViewBag.situation = SituationSelection(House.situation);
            ViewBag.house = House;

            return View();

        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(House obj)
        {
            //var Item = await _houseRepository.GetById(id);
            _houseRepository.Update(obj);
            await _houseRepository.SaveChangesAsync();
            return RedirectToAction("ShowAll");

        }
    }
}
