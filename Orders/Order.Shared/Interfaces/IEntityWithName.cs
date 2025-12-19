using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Shared.Interfaces;

public interface IEntityWithName
{
    string Name { get; set; }
}