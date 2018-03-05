using CQRSlite.Commands;
using System;

namespace Petitions.Domain.Commands
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; set; }

        public int ExpectedVersion { get; set; }
    }
}
