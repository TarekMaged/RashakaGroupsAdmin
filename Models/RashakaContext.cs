using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RashakaGroupsAdmin.Models;

public partial class RashakaContext : DbContext
{
    public RashakaContext()
    {
    }

    public RashakaContext(DbContextOptions<RashakaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AdminRole> AdminRoles { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupEvent> GroupEvents { get; set; }

    public virtual DbSet<GroupEventComment> GroupEventComments { get; set; }

    public virtual DbSet<GroupPost> GroupPosts { get; set; }

    public virtual DbSet<GroupPostComment> GroupPostComments { get; set; }

    public virtual DbSet<GroupPostLike> GroupPostLikes { get; set; }

    public virtual DbSet<GroupPostReport> GroupPostReports { get; set; }

    public virtual DbSet<GroupReport> GroupReports { get; set; }

    public virtual DbSet<GroupType> GroupTypes { get; set; }

    public virtual DbSet<GroupUser> GroupUsers { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=85.195.94.22;Initial Catalog=Rashaka;TrustServerCertificate=True;User ID=sa;password=hV5}aF2%cL7*;Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasIndex(e => e.allStepsCount, "Index_allStepsCount");

            entity.HasIndex(e => e.currentDayDate, "Index_currentDayDate");

            entity.HasIndex(e => e.guid, "Index_guid");

            entity.HasIndex(e => new { e.iso, e.gender, e.age, e.lastSyncUploadDate }, "Index_iso");

            entity.HasIndex(e => new { e.iso, e.lastSyncUploadDate }, "Index_iso_lastSyncUploadDate");

            entity.HasIndex(e => new { e.lastSyncUploadDate, e.monthStepsCount, e.weekStepsCount }, "Index_lastSyncUploadDate_monthStepsCount-weekStepsCount");

            entity.HasIndex(e => e.publicId, "Index_publicId");

            entity.HasIndex(e => new { e.yesterdayDate, e.yesterdayStepsCount }, "Index_yesterdayDate_yesterdayStepsCount");

            entity.HasIndex(e => e.publicId, "UQ__Accounts__26B3958589BB85BF").IsUnique();

            entity.Property(e => e.allCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.allDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.allStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.applicationGoal).HasMaxLength(100);
            entity.Property(e => e.birthDate).HasColumnType("datetime");
            entity.Property(e => e.chronicDiseaseId).HasMaxLength(20);
            entity.Property(e => e.city)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.country).HasMaxLength(50);
            entity.Property(e => e.currentDayDate).HasColumnType("date");
            entity.Property(e => e.currentDayStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.deleteStatus).HasMaxLength(50);
            entity.Property(e => e.desiredWeight).HasDefaultValueSql("((0))");
            entity.Property(e => e.email)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.email2).HasMaxLength(50);
            entity.Property(e => e.femaleStatus).HasMaxLength(200);
            entity.Property(e => e.fullName).HasMaxLength(50);
            entity.Property(e => e.gender).HasMaxLength(10);
            entity.Property(e => e.goal)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.height).HasDefaultValueSql("((0))");
            entity.Property(e => e.image)
                .HasMaxLength(500)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.isImageUpdated).HasDefaultValueSql("((0))");
            entity.Property(e => e.isNameUpdated).HasDefaultValueSql("((0))");
            entity.Property(e => e.iso)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.lastDayStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.lastSyncDownloadDate).HasColumnType("datetime");
            entity.Property(e => e.lastSyncUploadDate).HasColumnType("datetime");
            entity.Property(e => e.lastUserOrderNotificationDate).HasColumnType("date");
            entity.Property(e => e.mealsLastUploadDate).HasColumnType("datetime");
            entity.Property(e => e.mobile).HasMaxLength(20);
            entity.Property(e => e.monthCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.monthDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.monthStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.monthStepsDate).HasColumnType("datetime");
            entity.Property(e => e.name)
                .HasMaxLength(200)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.publicId).HasMaxLength(200);
            entity.Property(e => e.purchaseStatus).HasMaxLength(20);
            entity.Property(e => e.todayCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.todayDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.type)
                .HasMaxLength(20)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.userActivity)
                .HasMaxLength(50)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.weekCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekDesiredWeight).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekStepsDate).HasColumnType("datetime");
            entity.Property(e => e.weight).HasDefaultValueSql("((0))");
            entity.Property(e => e.yesterdayCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.yesterdayDate).HasColumnType("date");
            entity.Property(e => e.yesterdayDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.yesterdayStepsCount).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<AdminRole>(entity =>
        {
            entity.Property(e => e.name).HasMaxLength(50);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Groups_1");

            entity.HasIndex(e => new { e.isDeleted, e.typeId, e.privacyId }, "INDEX_isDeleted_typeId_privacyId");

            entity.HasIndex(e => new { e.isDeleted, e.typeId, e.privacy }, "Index_isDeleted_typeId_privacy");

            entity.HasIndex(e => new { e.id, e.typeId, e.privacy }, "NonClusteredIndex-20211028-140022");

            entity.HasIndex(e => new { e.creatorId, e.typeId, e.isDeleted }, "NonClusteredIndex-20220307-023428");

            entity.HasIndex(e => new { e.isDeleted, e.id, e.privacyId, e.typeId }, "NonClusteredIndex-20220331-024411");

            entity.HasIndex(e => e.isPinned, "NonClusteredIndex-isPinned");

            entity.HasIndex(e => new { e.isDeleted, e.privacyId }, "isDeleted_privacyId");

            entity.Property(e => e.city).HasMaxLength(50);
            entity.Property(e => e.country).HasMaxLength(50);
            entity.Property(e => e.coverImage).HasMaxLength(200);
            entity.Property(e => e.date).HasColumnType("date");
            entity.Property(e => e.goal).HasMaxLength(50);
            entity.Property(e => e.image).HasMaxLength(200);
            entity.Property(e => e.iso).HasMaxLength(10);
            entity.Property(e => e.lat).HasColumnType("decimal(19, 16)");
            entity.Property(e => e.lng).HasColumnType("decimal(19, 16)");
            entity.Property(e => e.name).HasMaxLength(300);
            entity.Property(e => e.privacy)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'opened')");
            entity.Property(e => e.reportsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.shareCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.sponsor).HasMaxLength(200);
            entity.Property(e => e.type).HasMaxLength(50);
            entity.Property(e => e.viewsCount).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.creator).WithMany(p => p.Groups)
                .HasForeignKey(d => d.creatorId)
                .HasConstraintName("FK_Groups_Accounts");

            entity.HasOne(d => d.typeNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.typeId)
                .HasConstraintName("FK_Groups_GroupTypes");
        });

        modelBuilder.Entity<GroupEvent>(entity =>
        {
            entity.HasIndex(e => e.groupId, "NonClusteredIndex-20201222-044138");

            entity.HasIndex(e => e.isAllowed, "NonClusteredIndex-20221226-115028");

            entity.HasIndex(e => e.adminId, "missing_index_8_7");

            entity.Property(e => e.date).HasColumnType("date");
            entity.Property(e => e.dateFrom).HasColumnType("datetime");
            entity.Property(e => e.day).HasMaxLength(50);
            entity.Property(e => e.gender).HasMaxLength(20);
            entity.Property(e => e.image).HasMaxLength(100);
            entity.Property(e => e.image2).HasMaxLength(100);
            entity.Property(e => e.image3).HasMaxLength(100);
            entity.Property(e => e.latFrom).HasColumnType("decimal(19, 16)");
            entity.Property(e => e.lngFrom).HasColumnType("decimal(19, 16)");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.placeFrom).HasMaxLength(100);

            entity.HasOne(d => d.admin).WithMany(p => p.GroupEvents)
                .HasForeignKey(d => d.adminId)
                .HasConstraintName("FK_GroupEvents_Accounts");

            entity.HasOne(d => d.group).WithMany(p => p.GroupEvents)
                .HasForeignKey(d => d.groupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupEvents_Groups");
        });

        modelBuilder.Entity<GroupEventComment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_groupEventComments");

            entity.HasIndex(e => e.groupEventId, "NonClusteredIndex-20210930-122411");

            entity.Property(e => e.comment).HasMaxLength(200);
            entity.Property(e => e.date).HasColumnType("datetime");

            entity.HasOne(d => d.account).WithMany(p => p.GroupEventComments)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_groupEventComments_Accounts");

            entity.HasOne(d => d.groupEvent).WithMany(p => p.GroupEventComments)
                .HasForeignKey(d => d.groupEventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_groupEventComments_GroupEvents");
        });

        modelBuilder.Entity<GroupPost>(entity =>
        {
            entity.HasIndex(e => new { e.accountId, e.isAllowed }, "Index_accountId_isAllowed");

            entity.HasIndex(e => new { e.isAllowed, e.groupId, e.accountId, e.isPinned }, "Index_isAllowed_groupId_accountId");

            entity.HasIndex(e => new { e.isAllowed, e.id }, "Index_isAllowed_id");

            entity.Property(e => e.commentSystemCommentsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.commentsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.duration).HasMaxLength(50);
            entity.Property(e => e.durations).HasMaxLength(50);
            entity.Property(e => e.eventName).HasMaxLength(200);
            entity.Property(e => e.image).HasMaxLength(200);
            entity.Property(e => e.image2).HasMaxLength(200);
            entity.Property(e => e.image3)
                .HasMaxLength(200)
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.isAllowed).HasDefaultValueSql("((1))");
            entity.Property(e => e.reportsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.shareCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.shareImageUrl)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.shareLink)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.sharedGroupName).HasMaxLength(300);
            entity.Property(e => e.sharedStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.totalLikes).HasDefaultValueSql("((0))");
            entity.Property(e => e.viewsCount).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.account).WithMany(p => p.GroupPosts)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_GroupPosts_Accounts");

            entity.HasOne(d => d.group).WithMany(p => p.GroupPosts)
                .HasForeignKey(d => d.groupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupPosts_Groups");
        });

        modelBuilder.Entity<GroupPostComment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_groupPostComments");

            entity.HasIndex(e => e.groupPostId, "<Name of Missing Index, sysname,>");

            entity.Property(e => e.date).HasColumnType("datetime");

            entity.HasOne(d => d.account).WithMany(p => p.GroupPostComments)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_groupPostComments_Accounts");

            entity.HasOne(d => d.groupPost).WithMany(p => p.GroupPostComments)
                .HasForeignKey(d => d.groupPostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_groupPostComments_GroupPosts");
        });

        modelBuilder.Entity<GroupPostLike>(entity =>
        {
            entity.HasIndex(e => e.groupPostId, "Index_groupPostId");

            entity.HasIndex(e => new { e.accountId, e.groupPostId }, "NonClusteredIndex-20221024-204212");

            entity.HasOne(d => d.account).WithMany(p => p.GroupPostLikes)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_GroupPostLikes_Accounts");

            entity.HasOne(d => d.groupPost).WithMany(p => p.GroupPostLikes)
                .HasForeignKey(d => d.groupPostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupPostLikes_GroupPosts");
        });

        modelBuilder.Entity<GroupPostReport>(entity =>
        {
            entity.HasIndex(e => new { e.accountId, e.groupPostId }, "NonClusteredIndex-20221025-015842");

            entity.Property(e => e.date).HasColumnType("datetime");

            entity.HasOne(d => d.account).WithMany(p => p.GroupPostReports)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_GroupPostReports_Accounts");

            entity.HasOne(d => d.groupPost).WithMany(p => p.GroupPostReports)
                .HasForeignKey(d => d.groupPostId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupPostReports_GroupPosts");
        });

        modelBuilder.Entity<GroupReport>(entity =>
        {
            entity.Property(e => e.date).HasColumnType("datetime");

            entity.HasOne(d => d.account).WithMany(p => p.GroupReports)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_GroupReports_Accounts");

            entity.HasOne(d => d.group).WithMany(p => p.GroupReports)
                .HasForeignKey(d => d.groupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupReports_Groups");
        });

        modelBuilder.Entity<GroupType>(entity =>
        {
            entity.Property(e => e.englishName).HasMaxLength(20);
            entity.Property(e => e.name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasIndex(e => new { e.groupId, e.currentDayDate }, "<Name of Missing Index, sysname,>");

            entity.HasIndex(e => new { e.groupId, e.isAdmin, e.accountId }, "INDEX__groupId_isAdmin_accountId");

            entity.HasIndex(e => new { e.groupId, e.accountId }, "INDEX_groupId_accountId");

            entity.HasIndex(e => new { e.groupId, e.requestStatus }, "INDEX_groupId_requestStatus");

            entity.HasIndex(e => new { e.groupId, e.requestStatus }, "INDEX_groupId_requestStatusByYesterday");

            entity.HasIndex(e => new { e.groupId, e.requestStatus, e.accountId, e.lastUploadDate, e.weekDistance }, "INDEX_groupId_requestStatus_accountId_lastUploadDate_weekDistance");

            entity.HasIndex(e => new { e.groupId, e.requestStatus, e.accountId, e.monthStepsCount, e.lastUploadDate }, "Index_groupId_requestStatus_accountId_monthStepsCount_lastUploadDate");

            entity.HasIndex(e => e.accountId, "NonClusteredIndex-20201105-095246");

            entity.HasIndex(e => new { e.groupId, e.lastStepsOrder, e.id, e.currentStepsOrder, e.accountId }, "_dta_index_GroupUsers_6_308196148__K2_K29_K1_K28_K3");

            entity.HasIndex(e => e.groupId, "missing_index_5746_5745");

            entity.Property(e => e.activityTimeTodayDate).HasColumnType("date");
            entity.Property(e => e.allCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.allDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.allStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.currentDayDate).HasColumnType("date");
            entity.Property(e => e.currentDayStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.joinDate).HasColumnType("date");
            entity.Property(e => e.lastDayStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.lastUploadDate).HasColumnType("date");
            entity.Property(e => e.lastUserOrderNotificationDate).HasColumnType("date");
            entity.Property(e => e.monthCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.monthDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.monthStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.requestStatus).HasMaxLength(20);
            entity.Property(e => e.todayDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.weekStepsCount).HasDefaultValueSql("((0))");
            entity.Property(e => e.yesterdayCalories).HasDefaultValueSql("((0))");
            entity.Property(e => e.yesterdayDate).HasColumnType("date");
            entity.Property(e => e.yesterdayDistance).HasDefaultValueSql("((0))");
            entity.Property(e => e.yesterdayStepsCount).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.account).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.accountId)
                .HasConstraintName("FK_GroupUsers_Accounts");

            entity.HasOne(d => d.group).WithMany(p => p.GroupUsers)
                .HasForeignKey(d => d.groupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupUsers_Groups");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("Login");

            entity.Property(e => e.groupId).HasMaxLength(50);
            entity.Property(e => e.password).HasMaxLength(200);
            entity.Property(e => e.role).HasMaxLength(50);
            entity.Property(e => e.userName).HasMaxLength(50);

            entity.HasOne(d => d.roleNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.roleId)
                .HasConstraintName("FK_Login_AdminRoles");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.udId, "NonClusteredIndex-20230515-113759");

            entity.HasIndex(e => e.udId, "UC_udId").IsUnique();

            entity.Property(e => e.accessToken).HasMaxLength(500);
            entity.Property(e => e.appVersion).HasMaxLength(50);
            entity.Property(e => e.city).HasMaxLength(100);
            entity.Property(e => e.date).HasColumnType("datetime");
            entity.Property(e => e.deviceName).HasMaxLength(200);
            entity.Property(e => e.iso).HasMaxLength(10);
            entity.Property(e => e.udId).HasMaxLength(300);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
