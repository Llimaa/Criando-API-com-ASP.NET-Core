﻿using DevStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevStore.Domain.StoreContext.Commands.CustomerCommands.Output
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult(bool sucess, string mensagem, object data)
        {
            Sucess = sucess;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}
