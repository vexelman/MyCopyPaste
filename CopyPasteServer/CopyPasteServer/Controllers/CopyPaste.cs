using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopyPasteDAL.Models;
using CopyPasteBLL;
namespace CopyPasteServer.Controllers
{
    [ApiController]
    [Route("CopyPaste")]
    public class CopyPaste : Controller
    {
        //use dependency injection

        IActionsBLL ActionsBLL;
        public CopyPaste(IActionsBLL _ActionsBLL)
        {
            this.ActionsBLL = _ActionsBLL;
        }

        //function that sends the item to add it to the BLL

        [HttpPost("Add")]
        public ActionResult Add(Data item)
        {
            AddRes res = new AddRes();
            if (ActionsBLL.AddItem(item))
                res.res = true;
            else
                res.res = false;
            return Ok(res);

        }

        //function that sends the url to find the data in the BLL

        [HttpGet("GetByUrl/{url}")]
        public ActionResult GetByUrl(string url)
        {
            return Ok(ActionsBLL.GetByUrl(url));
        }

        //function that brings the url to the client
        [HttpGet("GetUrl")]
        public ActionResult GetUrl()
        {
            UrlRes newUrl=new UrlRes();
            var rng = new Random();

            //function to get a random number

            newUrl.url = rng.GetHashCode().ToString();

            //functio that sends the url to check if it exists
            //if the number does not exist , send the url to the client

            if (ActionsBLL.IsExistUrl(newUrl.url))
                return Ok(newUrl);

            //if the number exists , perform the function again

            return Ok(GetUrl());
           


        }
    }
}
