using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SKMBingo.Models.Db;

namespace SKMBingo.Migrations
{
    [DbContext(typeof(BingoContext))]
    [Migration("20160930091828_Init-Model")]
    partial class InitModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("SKMBingo.Models.Db.BingoRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("birid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("birdate");

                    b.Property<int>("FieldId")
                        .HasColumnName("birfldid");

                    b.HasKey("ID");

                    b.HasIndex("FieldId");

                    b.ToTable("bingorecord");
                });

            modelBuilder.Entity("SKMBingo.Models.Db.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fldid");

                    b.Property<int>("FieldNumber")
                        .HasColumnName("fldno");

                    b.Property<bool>("IsActive")
                        .HasColumnName("fldactive");

                    b.Property<string>("Name")
                        .HasColumnName("fldname");

                    b.HasKey("Id");

                    b.ToTable("field");
                });

            modelBuilder.Entity("SKMBingo.Models.Db.BingoRecord", b =>
                {
                    b.HasOne("SKMBingo.Models.Db.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
