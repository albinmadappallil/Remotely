﻿using Tess.Shared.Enums;
using System.Runtime.Serialization;

namespace Tess.Shared.Models.RemoteControlDtos
{
    [DataContract]
    public class SelectScreenDto : BaseDto
    {
        [DataMember(Name = "DisplayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "DtoType")]
        public override BaseDtoType DtoType { get; init; } = BaseDtoType.SelectScreen;
    }
}
