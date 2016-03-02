using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;
using DataAccess.Domain;

namespace DataAccess.Context
{
    public class MSSQLContext : DbContext
    {
        #region 构造
        public MSSQLContext()
            : base("mssql")
        {
            //this.Database.Initialize(false);
        }
        #endregion

        #region 实体模型
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //配置EF实体关系，一对一，一对多，多对多

            var admin = modelBuilder.Entity<AdminInfo>().HasEntitySetName("AdminInfo");
            admin.HasOptional(c => c.Role).WithMany()
                .HasForeignKey(ba => ba.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>().HasEntitySetName("Role").Ignore(c => c.Permission);

            modelBuilder.Entity<Operate>().HasEntitySetName("Operate");

            modelBuilder.Entity<PurviewField>().HasEntitySetName("PurviewField");

            modelBuilder.Entity<MyProblem>().HasKey(a => a.ID).ToTable("MyProblem").HasEntitySetName("MyProblem");

            modelBuilder.Entity<Page>().HasKey(a => a.Id).ToTable("Page").HasEntitySetName("Page");

            modelBuilder.Entity<AD>().HasKey(a => a.Id).ToTable("AD").HasEntitySetName("AD");

            modelBuilder.Entity<Video>().HasKey(a => a.Id).ToTable("Video").HasEntitySetName("Video");

            modelBuilder.Entity<WechatConfig>().HasKey(a => a.ID).ToTable("WechatConfig").HasEntitySetName("WechatConfig");

            modelBuilder.Entity<WechatRedPack>().HasKey(a => a.ID).ToTable("WechatRedPack").HasEntitySetName("WechatRedPack");

            modelBuilder.Entity<WechatTemplate>().HasKey(a => a.ID).ToTable("WechatTemplate").HasEntitySetName("WechatTemplate");

            modelBuilder.Entity<WechatUser>().HasKey(a => a.ID).ToTable("WechatUser").HasEntitySetName("WechatUser");

            #region 问卷调查
            var questions = modelBuilder.Entity<Question>().HasKey(a => a.ID).ToTable("Question").HasEntitySetName("Question");
            var questionItems = modelBuilder.Entity<QuestionItem>().HasKey(a => a.ID).ToTable("QuestionItem").HasEntitySetName("QuestionItem");
            var questionSelects = modelBuilder.Entity<QuestionSelect>().HasKey(a => a.ID).ToTable("QuestionSelect").HasEntitySetName("QuestionSelect");
            var questionSelectUsers = modelBuilder.Entity<QuestionSelectUser>().HasKey(a => new { a.QuestionSelectID, a.WechatUserID }).ToTable("QuestionSelectUser").HasEntitySetName("QuestionSelectUser");
            var questionUsers = modelBuilder.Entity<QuestionUser>().HasKey(a => new { a.QuestionID, a.WechatUserID }).ToTable("QuestionUser").HasEntitySetName("QuestionUser");

            questions.HasMany(a => a.QuestionItems).WithRequired().HasForeignKey(a => a.QuestionID);
            questions.HasMany(a => a.QuestionUsers).WithRequired().HasForeignKey(a => a.QuestionID);
            questionItems.HasMany(a => a.QuestionSelects).WithRequired().HasForeignKey(a => a.QuestionItemID);
            questionItems.HasRequired(a => a.Question).WithMany().HasForeignKey(a => a.QuestionID);
            questionSelects.HasRequired(a => a.QuestionItem).WithMany().HasForeignKey(a => a.QuestionItemID);
            questionSelects.HasMany(a => a.QuestionSelectUsers).WithRequired().HasForeignKey(a=>a.QuestionSelectID);
            questionSelectUsers.HasRequired(a => a.QuestionSelect).WithMany().HasForeignKey(a => a.QuestionSelectID);
            questionUsers.HasRequired(a => a.WechatUser).WithMany().HasForeignKey(a => a.WechatUserID);
            questionUsers.HasRequired(a => a.Question).WithMany().HasForeignKey(a => a.QuestionID);
            #endregion

            #region 创新疫苗文章
            modelBuilder.Entity<InnovateFeed>().HasKey(a => a.ID).ToTable("InnovateFeed").HasEntitySetName("InnovateFeed");
            #endregion

            #region 会议数据
            var meetings = modelBuilder.Entity<Meeting>().HasKey(a => a.ID).ToTable("Meeting").HasEntitySetName("Meeting");
            var meetingUsers = modelBuilder.Entity<MeetingUser>().HasKey(a => new { a.MeetingID, a.WechatUserID }).ToTable("MeetingUser").HasEntitySetName("MeetingUser");
            meetings.HasMany(a => a.MeetingUsers).WithRequired().HasForeignKey(a => a.MeetingID);
            meetingUsers.HasRequired(a => a.WechatUser).WithMany().HasForeignKey(a => a.WechatUserID);
            meetingUsers.HasRequired(a => a.Meeting).WithMany().HasForeignKey(a => a.MeetingID);
            #endregion

            modelBuilder.Entity<VaccineType>().HasKey(a => a.Id).ToTable("VaccineType").HasEntitySetName("VaccineType")
                .HasMany(a => a.LBSVaccineTypes).WithRequired().HasForeignKey(a => a.VaccineTypeId);

            modelBuilder.Entity<LBS>().HasKey(a => a.Id).ToTable("LBS").HasEntitySetName("LBS")
                .HasMany(a => a.LBSVaccineTypes).WithRequired().HasForeignKey(a => a.LBSId);


            var LBSVaccineTypes = modelBuilder.Entity<LBSVaccineType>().HasKey(a => new { a.LBSId, a.VaccineTypeId }).ToTable("LBSVaccineType").HasEntitySetName("LBSVaccineType");
            LBSVaccineTypes.HasRequired(a => a.LBS).WithMany().HasForeignKey(a => a.LBSId);
            LBSVaccineTypes.HasRequired(a => a.VaccineType).WithMany().HasForeignKey(a => a.VaccineTypeId);

            var users = modelBuilder.Entity<Users>();

            var features = modelBuilder.Entity<Features>().HasKey(b => b.ID);
            features.Property(c => c.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            features.Ignore(c => c.Childrens);

            modelBuilder.Entity<SiteSettings>().HasEntitySetName("SiteSettings");

            modelBuilder.Entity<CycleTable>().HasEntitySetName("CycleTable");

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
