﻿using CarParts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Persistence.Configurations
{
    public class SellerListConfiguration : IEntityTypeConfiguration<SellerList>
    {
        public void Configure(EntityTypeBuilder<SellerList> builder)
        {
            builder.HasOne(x => x.Product).WithMany(x => x.SellerLists).HasForeignKey(x => x.ProductId);
        }
    }
}
