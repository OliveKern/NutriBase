using System;
using System.ComponentModel.DataAnnotations;

namespace NutriBase.Logic.Models;

public class VersionModel : IdentityModel
{
    [Timestamp]
    public byte[] RowVersion { get; internal set; } = new byte[0];
}
