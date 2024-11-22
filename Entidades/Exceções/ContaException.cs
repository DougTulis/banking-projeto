using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK_MELHORADO.Entidades.Exceções {
    internal class ContaException : ApplicationException {
        public ContaException(string? message) : base(message) {
        }
    }
}
