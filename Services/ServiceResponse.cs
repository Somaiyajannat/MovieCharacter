using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharacter.Services
{
    public class ServiceResponse<T>
    {
        public T? Data {get;set;}
        public bool Status{get;set;}
        public string Message{get;set;}
    }
}