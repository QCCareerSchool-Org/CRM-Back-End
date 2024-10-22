// <copyright file="QcContext.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Data;

using CRM.Models;
using Microsoft.EntityFrameworkCore;

public partial class QcContext : DbContext
{
    public QcContext()
    {
    }

    public QcContext(DbContextOptions<QcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AffiliateId> AffiliateIds { get; set; }

    public virtual DbSet<BonusItem> BonusItems { get; set; }

    public virtual DbSet<BonusItemShipment> BonusItemShipments { get; set; }

    public virtual DbSet<BonusItemsCourse> BonusItemsCourses { get; set; }

    public virtual DbSet<CardeasexmlResponse> CardeasexmlResponses { get; set; }

    public virtual DbSet<CardeasexmlToken> CardeasexmlTokens { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CountryCallingCode> CountryCallingCodes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<EmailMessage> EmailMessages { get; set; }

    public virtual DbSet<EmailMessageType> EmailMessageTypes { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<EselectPlusResponse> EselectPlusResponses { get; set; }

    public virtual DbSet<EselectPlusToken> EselectPlusTokens { get; set; }

    public virtual DbSet<FailedTransaction> FailedTransactions { get; set; }

    public virtual DbSet<Flag> Flags { get; set; }

    public virtual DbSet<GeoLocation> GeoLocations { get; set; }

    public virtual DbSet<GlobalChequePost> GlobalChequePosts { get; set; }

    public virtual DbSet<GlobalPaymentMethod> GlobalPaymentMethods { get; set; }

    public virtual DbSet<GlobalPaymentType> GlobalPaymentTypes { get; set; }

    public virtual DbSet<GlobalPaysafeTransaction> GlobalPaysafeTransactions { get; set; }

    public virtual DbSet<GlobalTransaction> GlobalTransactions { get; set; }

    public virtual DbSet<GlobalTransactionBreakdown> GlobalTransactionBreakdowns { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<PaysafeResponse> PaysafeResponses { get; set; }

    public virtual DbSet<PaysafeToken> PaysafeTokens { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsFlag> StudentsFlags { get; set; }

    public virtual DbSet<TaxReceipt> TaxReceipts { get; set; }

    public virtual DbSet<TimeZone> TimeZones { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionReattemptInfo> TransactionReattemptInfos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AffiliateId>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PRIMARY");

            entity
                .ToTable("affiliate_ids")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.EnrollmentId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_id");
            entity.Property(e => e.AffiliateId1)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("affiliate_id");

            entity.HasOne(d => d.Enrollment).WithOne(p => p.AffiliateId)
                .HasForeignKey<AffiliateId>(d => d.EnrollmentId)
                .HasConstraintName("affiliate_ids_ibfk_1");
        });

        modelBuilder.Entity<BonusItem>(entity =>
        {
            entity.HasKey(e => e.BonusItemId).HasName("PRIMARY");

            entity.ToTable("bonus_items");

            entity.Property(e => e.BonusItemId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("bonus_item_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Default)
                .HasComment("new enrollments should default to getting this item")
                .HasColumnName("default");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Enabled)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasComment("at enrollment time, this item will show up in the list of possible bonus items")
                .HasColumnName("enabled");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.ShipImmediately)
                .HasComment("when a new enrollment includes this bonus item, the bonus item shipment will be set into a \"shipment pending\" state from the start")
                .HasColumnName("ship_immediately");
            entity.Property(e => e.Threshold)
                .HasColumnType("decimal(6,5) unsigned")
                .HasColumnName("threshold");
        });

        modelBuilder.Entity<BonusItemShipment>(entity =>
        {
            entity.HasKey(e => e.BonusItemShipmentId).HasName("PRIMARY");

            entity.ToTable("bonus_item_shipments");

            entity.HasIndex(e => e.BonusItemId, "bonus_item_id");

            entity.HasIndex(e => new { e.EnrollmentId, e.BonusItemId }, "enrollment_id_bonus_item_id").IsUnique();

            entity.Property(e => e.BonusItemShipmentId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("bonus_item_shipment_id");
            entity.Property(e => e.BonusItemId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("bonus_item_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.EnrollmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_id");
            entity.Property(e => e.Prepared)
                .HasColumnType("timestamp")
                .HasColumnName("prepared");
            entity.Property(e => e.Qualified)
                .HasColumnType("timestamp")
                .HasColumnName("qualified");
            entity.Property(e => e.Shipped)
                .HasColumnType("timestamp")
                .HasColumnName("shipped");
            entity.Property(e => e.Threshold)
                .HasColumnType("decimal(6,5) unsigned")
                .HasColumnName("threshold");

            entity.HasOne(d => d.BonusItem).WithMany(p => p.BonusItemShipments)
                .HasForeignKey(d => d.BonusItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bonus_item_shipments_bonus_items");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.BonusItemShipments)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("FK_bonus_item_shipments_enrollments");
        });

        modelBuilder.Entity<BonusItemsCourse>(entity =>
        {
            entity.HasKey(e => e.BonusItemCourseId).HasName("PRIMARY");

            entity.ToTable("bonus_items_courses");

            entity.HasIndex(e => new { e.BonusItemId, e.CourseId }, "bonus_item_id_course_id").IsUnique();

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.Property(e => e.BonusItemCourseId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("bonus_item_course_id");
            entity.Property(e => e.BonusItemId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("bonus_item_id");
            entity.Property(e => e.CourseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("course_id");

            entity.HasOne(d => d.BonusItem).WithMany(p => p.BonusItemsCourses)
                .HasForeignKey(d => d.BonusItemId)
                .HasConstraintName("FK_bonus_items_courses_bonus_items");

            entity.HasOne(d => d.Course).WithMany(p => p.BonusItemsCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_bonus_items_courses_courses");
        });

        modelBuilder.Entity<CardeasexmlResponse>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

            entity
                .ToTable("cardeasexml_responses")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalTransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("auth_code");
            entity.Property(e => e.CardEaseReference).HasColumnName("card_ease_reference");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .HasColumnName("message");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.ResultCode)
                .HasColumnType("tinyint(2)")
                .HasColumnName("result_code");
            entity.Property(e => e.TransactionTime)
                .HasComment("not supplied by processor")
                .HasColumnType("datetime")
                .HasColumnName("transaction_time");

            entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.CardeasexmlResponse)
                .HasForeignKey<CardeasexmlResponse>(d => d.GlobalTransactionId)
                .HasConstraintName("cardeasexml_responses_ibfk_1");
        });

        modelBuilder.Entity<CardeasexmlToken>(entity =>
        {
            entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

            entity
                .ToTable("cardeasexml_tokens")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalPaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_payment_method_id");
            entity.Property(e => e.CardHash)
                .HasMaxLength(28)
                .IsFixedLength()
                .HasColumnName("card_hash");
            entity.Property(e => e.CardReference).HasColumnName("card_reference");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");

            entity.HasOne(d => d.GlobalPaymentMethod).WithOne(p => p.CardeasexmlToken)
                .HasForeignKey<CardeasexmlToken>(d => d.GlobalPaymentMethodId)
                .HasConstraintName("cardeasexml_tokens_ibfk_1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("countries")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Iso31661, "iso 3166-1").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Eu).HasColumnName("eu");
            entity.Property(e => e.Iso31661)
                .HasColumnType("smallint(3) unsigned zerofill")
                .HasColumnName("iso 3166-1");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.NeedsPostalCode)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("needs_postal_code");
            entity.Property(e => e.NoShipping).HasColumnName("no_shipping");
            entity.Property(e => e.StudentCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_count");
        });

        modelBuilder.Entity<CountryCallingCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("country_calling_codes")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("smallint(5) unsigned")
                .HasColumnName("code");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("courses")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.SchoolId, "school_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.EnrollmentCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_count");
            entity.Property(e => e.Installment)
                .HasPrecision(10, 2)
                .HasColumnName("installment");
            entity.Property(e => e.MaxAssignments)
                .HasColumnType("int(11)")
                .HasColumnName("max_assignments");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Order)
                .HasDefaultValueSql("'50'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("order");
            entity.Property(e => e.Prefix)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("prefix");
            entity.Property(e => e.SchoolId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("school_id");

            entity.HasOne(d => d.School).WithMany(p => p.Courses)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("courses_ibfk_1");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("currencies")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Code, "code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Created)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.ExchangeRate)
                .HasPrecision(10, 5)
                .HasColumnName("exchange_rate");
            entity.Property(e => e.Modified)
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(5)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<EmailMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("email_messages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => new { e.CourseId, e.EmailMessageTypeId }, "course_id_2").IsUnique();

            entity.HasIndex(e => e.EmailMessageTypeId, "email_message_type_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CourseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("course_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.EmailMessageTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("email_message_type_id");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Sender)
                .HasMaxLength(255)
                .HasColumnName("sender");
            entity.Property(e => e.Subject)
                .HasMaxLength(40)
                .HasColumnName("subject");

            entity.HasOne(d => d.Course).WithMany(p => p.EmailMessages)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("email_messages_ibfk_1");

            entity.HasOne(d => d.EmailMessageType).WithMany(p => p.EmailMessages)
                .HasForeignKey(d => d.EmailMessageTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("email_messages_ibfk_2");
        });

        modelBuilder.Entity<EmailMessageType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("email_message_types")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("enrollments");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.CurrencyId, "currency_id");

            entity.HasIndex(e => e.EnrollmentDate, "enrollment_date");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "student_id_2").IsUnique();

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AccountId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("account_id");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.CourseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("course_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.CurrencyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("currency_id");
            entity.Property(e => e.Diploma).HasColumnName("diploma");
            entity.Property(e => e.DiplomaDate)
                .HasColumnType("timestamp")
                .HasColumnName("diploma_date");
            entity.Property(e => e.Discount)
                .HasPrecision(10, 2)
                .HasColumnName("discount");
            entity.Property(e => e.EnrollmentDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("timestamp")
                .HasColumnName("expiry_date");
            entity.Property(e => e.FastTrack)
                .HasDefaultValueSql("'0'")
                .HasColumnName("fast_track");
            entity.Property(e => e.GradEmailDate)
                .HasColumnType("timestamp")
                .HasColumnName("grad_email_date");
            entity.Property(e => e.GradEmailSkip).HasColumnName("grad_email_skip");
            entity.Property(e => e.HideFromShippingList).HasColumnName("hide_from_shipping_list");
            entity.Property(e => e.Installment)
                .HasPrecision(10, 2)
                .HasColumnName("installment");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.NoShipping).HasColumnName("no_shipping");
            entity.Property(e => e.NoStudentCenter).HasColumnName("no_student_center");
            entity.Property(e => e.PaymentDay)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("payment_day");
            entity.Property(e => e.PaymentFrequency)
                .HasDefaultValueSql("'monthly'")
                .HasColumnType("enum('monthly','bi-weekly','weekly')")
                .HasColumnName("payment_frequency");
            entity.Property(e => e.PaymentOverride).HasColumnName("payment_override");
            entity.Property(e => e.PaymentPlan)
                .HasColumnType("enum('full','accelerated','extended')")
                .HasColumnName("payment_plan");
            entity.Property(e => e.PaymentStart)
                .HasColumnType("timestamp")
                .HasColumnName("payment_start");
            entity.Property(e => e.PreparedDate)
                .HasColumnType("timestamp")
                .HasColumnName("prepared_date");
            entity.Property(e => e.ShippedDate)
                .HasColumnType("timestamp")
                .HasColumnName("shipped_date");
            entity.Property(e => e.ShippingNote)
                .HasColumnType("text")
                .HasColumnName("shipping_note")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Status)
                .HasColumnType("enum('W','H','T','G','R')")
                .HasColumnName("status");
            entity.Property(e => e.StatusDate)
                .HasColumnType("timestamp")
                .HasColumnName("status_date");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("enrollments_ibfk_2");

            entity.HasOne(d => d.Currency).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("enrollments_ibfk_3");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("enrollments_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("enrollments_ibfk_4");
        });

        modelBuilder.Entity<EselectPlusResponse>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

            entity
                .ToTable("eselect_plus_responses")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalTransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("auth_code");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Message)
                .HasMaxLength(100)
                .HasColumnName("message");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.OrderId)
                .HasMaxLength(50)
                .HasColumnName("order_id");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(18)
                .IsFixedLength()
                .HasColumnName("reference_number");
            entity.Property(e => e.ResponseCode)
                .HasColumnType("tinyint(3)")
                .HasColumnName("response_code");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionNumber)
                .HasMaxLength(255)
                .HasColumnName("transaction_number");
            entity.Property(e => e.TransactionTime)
                .HasColumnType("time")
                .HasColumnName("transaction_time");

            entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.EselectPlusResponse)
                .HasForeignKey<EselectPlusResponse>(d => d.GlobalTransactionId)
                .HasConstraintName("eselect_plus_responses_ibfk_1");
        });

        modelBuilder.Entity<EselectPlusToken>(entity =>
        {
            entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

            entity
                .ToTable("eselect_plus_tokens")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.DataKey, "data_key").IsUnique();

            entity.Property(e => e.GlobalPaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_payment_method_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.DataKey)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("data_key")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");

            entity.HasOne(d => d.GlobalPaymentMethod).WithOne(p => p.EselectPlusToken)
                .HasForeignKey<EselectPlusToken>(d => d.GlobalPaymentMethodId)
                .HasConstraintName("eselect_plus_tokens_ibfk_1");
        });

        modelBuilder.Entity<FailedTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("failed_transactions")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AccountId, "account_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AccountId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("account_id");
        });

        modelBuilder.Entity<Flag>(entity =>
        {
            entity.HasKey(e => e.FlagId).HasName("PRIMARY");

            entity.ToTable("flags");

            entity.Property(e => e.FlagId)
                .HasMaxLength(191)
                .HasColumnName("flag_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Name)
                .HasMaxLength(1024)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GeoLocation>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("geo_locations");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.Latitude)
                .HasPrecision(10, 7)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(10, 7)
                .HasColumnName("longitude");
        });

        modelBuilder.Entity<GlobalChequePost>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

            entity
                .ToTable("global_cheque_posts")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalTransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Success)
                .HasColumnType("tinyint(4)")
                .HasColumnName("success");

            entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.GlobalChequePost)
                .HasForeignKey<GlobalChequePost>(d => d.GlobalTransactionId)
                .HasConstraintName("global_cheque_posts_ibfk_1");
        });

        modelBuilder.Entity<GlobalPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

            entity
                .ToTable("global_payment_methods")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.GlobalPaymentMethodId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_payment_method_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.ExpiryMonth)
                .HasColumnType("tinyint(2) unsigned zerofill")
                .HasColumnName("expiry_month");
            entity.Property(e => e.ExpiryYear)
                .HasColumnType("smallint(4) unsigned")
                .HasColumnName("expiry_year");
            entity.Property(e => e.GlobalPaymentTypeId)
                .HasMaxLength(25)
                .HasDefaultValueSql("'Paysafe'")
                .HasColumnName("global_payment_type_id");
            entity.Property(e => e.GlobalTransactionCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_count");
            entity.Property(e => e.MaskedPan)
                .HasMaxLength(20)
                .HasColumnName("masked_pan");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Primary).HasColumnName("primary");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Student).WithMany(p => p.GlobalPaymentMethods)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("global_payment_methods_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.GlobalPaymentMethods)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("global_payment_methods_ibfk_2");
        });

        modelBuilder.Entity<GlobalPaymentType>(entity =>
        {
            entity.HasKey(e => e.GlobalPaymentTypeId).HasName("PRIMARY");

            entity
                .ToTable("global_payment_types")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalPaymentTypeId)
                .HasMaxLength(25)
                .HasColumnName("global_payment_type_id");
        });

        modelBuilder.Entity<GlobalPaysafeTransaction>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

            entity
                .ToTable("global_paysafe_transactions")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalTransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.AuthorizationId).HasColumnName("authorization_id");

            entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.GlobalPaysafeTransaction)
                .HasForeignKey<GlobalPaysafeTransaction>(d => d.GlobalTransactionId)
                .HasConstraintName("global_paysafe_transactions_ibfk_1");
        });

        modelBuilder.Entity<GlobalTransaction>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

            entity
                .ToTable("global_transactions")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.GlobalPaymentMethodId, "global_payment_method_id");

            entity.Property(e => e.GlobalTransactionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.Amount)
                .HasPrecision(9, 2)
                .HasColumnName("amount");
            entity.Property(e => e.AttemptedAmount)
                .HasPrecision(9, 2)
                .HasColumnName("attempted_amount");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ExtraCharge).HasColumnName("extra_charge");
            entity.Property(e => e.GlobalPaymentMethodId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_payment_method_id");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Origin)
                .HasDefaultValueSql("'auto'")
                .HasColumnType("enum('auto','manual','imported','student initiated')")
                .HasColumnName("origin");
            entity.Property(e => e.ParentGlobalTransactionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("parent_global_transaction_id");
            entity.Property(e => e.RefundedAmount)
                .HasColumnType("decimal(9,2) unsigned")
                .HasColumnName("refunded_amount");
            entity.Property(e => e.Severity)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("severity");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.TransactionDate)
                .HasComment("the date this payment is registered for")
                .HasColumnName("transaction_date");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'charge'")
                .HasColumnType("enum('charge','refund','chargeback','nsf fee','void')")
                .HasColumnName("type");
            entity.Property(e => e.UsdAmount)
                .HasPrecision(9, 2)
                .HasColumnName("USD_amount");
            entity.Property(e => e.UsdRefundedAmount)
                .HasColumnType("decimal(9,2) unsigned")
                .HasColumnName("USD_refunded_amount");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.Voided).HasColumnName("voided");

            entity.HasOne(d => d.GlobalPaymentMethod).WithMany(p => p.GlobalTransactions)
                .HasForeignKey(d => d.GlobalPaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("global_transactions_ibfk_1");
        });

        modelBuilder.Entity<GlobalTransactionBreakdown>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionBreakdownId).HasName("PRIMARY");

            entity
                .ToTable("global_transaction_breakdowns")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

            entity.HasIndex(e => e.GlobalTransactionId, "global_transaction_id");

            entity.Property(e => e.GlobalTransactionBreakdownId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_breakdown_id");
            entity.Property(e => e.Amount)
                .HasPrecision(9, 2)
                .HasColumnName("amount");
            entity.Property(e => e.AttemptedAmount)
                .HasPrecision(9, 2)
                .HasColumnName("attempted_amount");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.EnrollmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_id");
            entity.Property(e => e.GlobalTransactionId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.UsdAmount)
                .HasPrecision(9, 2)
                .HasColumnName("USD_amount");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.GlobalTransactionBreakdowns)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("global_transaction_breakdowns_ibfk_2");

            entity.HasOne(d => d.GlobalTransaction).WithMany(p => p.GlobalTransactionBreakdowns)
                .HasForeignKey(d => d.GlobalTransactionId)
                .HasConstraintName("global_transaction_breakdowns_ibfk_1");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("languages")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Enabled).HasColumnName("enabled");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NativeName)
                .HasMaxLength(255)
                .HasColumnName("native_name");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notes");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CourseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("course_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Note1).HasColumnName("note");
            entity.Property(e => e.Starred).HasColumnName("starred");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("'automatic'")
                .HasColumnType("enum('general','automatic','tutorial')")
                .HasColumnName("type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Notes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("notes_ibfk_3");

            entity.HasOne(d => d.Student).WithMany(p => p.Notes)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("notes_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Notes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("notes_ibfk_2");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment_methods", tb => tb.HasComment("history of payment methods used by enrollments"));

            entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

            entity.HasIndex(e => e.PaymentTypeId, "payment_type_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CardeasexmlCardHash)
                .HasMaxLength(28)
                .IsFixedLength()
                .HasColumnName("cardeasexml_card_hash")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.CardeasexmlCardReference)
                .HasColumnName("cardeasexml_card_reference")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Disabled).HasColumnName("disabled");
            entity.Property(e => e.EnrollmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_id");
            entity.Property(e => e.EselectPlusDataKey)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("eselect_plus_data_key")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.EselectPlusIssuerId)
                .HasMaxLength(36)
                .HasColumnName("eselect_plus_issuer_id");
            entity.Property(e => e.ExpiryMonth)
                .HasColumnType("tinyint(2) unsigned zerofill")
                .HasColumnName("expiry_month");
            entity.Property(e => e.ExpiryYear)
                .HasColumnType("smallint(4) unsigned")
                .HasColumnName("expiry_year");
            entity.Property(e => e.InitialTransactionId).HasColumnName("initial_transaction_id");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Notified)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("notified");
            entity.Property(e => e.Pan)
                .HasMaxLength(20)
                .HasColumnName("pan")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.PaymentTypeId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("payment_type_id");
            entity.Property(e => e.PaysafeCardId)
                .HasColumnName("paysafe_card_id")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.PaysafeCompany)
                .HasColumnType("enum('CA','GB','US')")
                .HasColumnName("paysafe_company");
            entity.Property(e => e.PaysafePaymentToken)
                .HasColumnName("paysafe_payment_token")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.PaysafeProfileId)
                .HasColumnName("paysafe_profile_id")
                .UseCollation("ascii_bin")
                .HasCharSet("ascii");
            entity.Property(e => e.Primary).HasColumnName("primary");
            entity.Property(e => e.TransactionCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("transaction_count");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("payment_methods_ibfk_1");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.PaymentMethods)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_methods_ibfk_2");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("payment_types")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PaysafeResponse>(entity =>
        {
            entity.HasKey(e => e.GlobalTransactionId).HasName("PRIMARY");

            entity
                .ToTable("paysafe_responses")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalTransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_transaction_id");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(50)
                .HasColumnName("auth_code");
            entity.Property(e => e.AuthorizationId).HasColumnName("authorization_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.MerchantRefNum)
                .HasMaxLength(255)
                .HasColumnName("merchant_ref_num");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TxnTime)
                .HasColumnType("datetime")
                .HasColumnName("txn_time");

            entity.HasOne(d => d.GlobalTransaction).WithOne(p => p.PaysafeResponse)
                .HasForeignKey<PaysafeResponse>(d => d.GlobalTransactionId)
                .HasConstraintName("paysafe_responses_ibfk_1");
        });

        modelBuilder.Entity<PaysafeToken>(entity =>
        {
            entity.HasKey(e => e.GlobalPaymentMethodId).HasName("PRIMARY");

            entity
                .ToTable("paysafe_tokens")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.GlobalPaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("global_payment_method_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.Company)
                .HasDefaultValueSql("'CA'")
                .HasColumnType("enum('CA','US','GB')")
                .HasColumnName("company");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(80)
                .HasColumnName("payment_token");
            entity.Property(e => e.ProfileId).HasColumnName("profile_id");

            entity.HasOne(d => d.GlobalPaymentMethod).WithOne(p => p.PaysafeToken)
                .HasForeignKey<PaysafeToken>(d => d.GlobalPaymentMethodId)
                .HasConstraintName("paysafe_tokens_ibfk_1");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("prices")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.CurrencyId, "currency_id");

            entity.HasIndex(e => e.ProvinceId, "province_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("cost");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country_id");
            entity.Property(e => e.CourseId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("course_id");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.CurrencyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("currency_id");
            entity.Property(e => e.Enabled)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(1) unsigned")
                .HasColumnName("enabled");
            entity.Property(e => e.Modified)
                .HasColumnType("datetime")
                .HasColumnName("modified");
            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("province_id");
            entity.Property(e => e.ShippingCost)
                .HasColumnType("decimal(10,2) unsigned")
                .HasColumnName("shipping_cost");

            entity.HasOne(d => d.Country).WithMany(p => p.Prices)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("prices_ibfk_2");

            entity.HasOne(d => d.Course).WithMany(p => p.Prices)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prices_ibfk_1");

            entity.HasOne(d => d.Currency).WithMany(p => p.Prices)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prices_ibfk_4");

            entity.HasOne(d => d.Province).WithMany(p => p.Prices)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("prices_ibfk_3");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("provinces")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => new { e.CountryId, e.Code }, "code").IsUnique();

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("name");
            entity.Property(e => e.StudentCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_count");

            entity.HasOne(d => d.Country).WithMany(p => p.Provinces)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provinces_ibfk_1");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId).HasName("PRIMARY");

            entity.ToTable("refresh_tokens");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => e.Token, "token").IsUnique();

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.RefreshTokenId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("refresh_token_id");
            entity.Property(e => e.Browser)
                .HasMaxLength(191)
                .HasColumnName("browser");
            entity.Property(e => e.BrowserVersion)
                .HasMaxLength(191)
                .HasColumnName("browser_version");
            entity.Property(e => e.City)
                .HasMaxLength(191)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Expiry)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("expiry");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(16)
                .HasColumnName("ip_address");
            entity.Property(e => e.Latitude)
                .HasPrecision(7, 4)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasPrecision(7, 4)
                .HasColumnName("longitude");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Os)
                .HasMaxLength(191)
                .HasColumnName("os");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.Token)
                .HasMaxLength(64)
                .IsFixedLength()
                .HasColumnName("token");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Student).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("refresh_tokens_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("refresh_tokens_ibfk_2");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("schools")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.CourseCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("course_count");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StudentCenterAccountType)
                .HasDefaultValueSql("'general'")
                .HasColumnType("enum('general','style','travel','pet','writing')")
                .HasColumnName("student_center_account_type");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("students");

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.HasIndex(e => e.LanguageId, "language_id");

            entity.HasIndex(e => e.ProvinceId, "province_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Address1)
                .HasMaxLength(40)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(40)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(31)
                .HasColumnName("city");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("country_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.CurrencyId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("currency_id");
            entity.Property(e => e.E164)
                .HasMaxLength(104)
                .HasComputedColumnSql("concat('+',`telephone_country_code`,replace(trim(leading '0' from `telephone_number`),'-',''))", false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .HasColumnName("email_address");
            entity.Property(e => e.EnrollmentCount)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_count");
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .HasColumnName("first_name");
            entity.Property(e => e.LanguageId)
                .HasDefaultValueSql("'41'")
                .HasColumnType("int(10) unsigned")
                .HasColumnName("language_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(40)
                .HasColumnName("last_name");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasComment("hashed password for API access")
                .HasColumnName("password")
                .UseCollation("latin1_bin")
                .HasCharSet("latin1");
            entity.Property(e => e.PaymentDay)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("payment_day");
            entity.Property(e => e.PaymentStart)
                .HasColumnType("timestamp")
                .HasColumnName("payment_start");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postal_code");
            entity.Property(e => e.ProvinceId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("province_id");
            entity.Property(e => e.Sex)
                .HasDefaultValueSql("'F'")
                .HasColumnType("enum('M','F')")
                .HasColumnName("sex");
            entity.Property(e => e.Sms).HasColumnName("sms");
            entity.Property(e => e.TelephoneCountryCode)
                .HasDefaultValueSql("'1'")
                .HasColumnType("smallint(3) unsigned")
                .HasColumnName("telephone_country_code");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(100)
                .HasColumnName("telephone_number")
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Students)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("students_ibfk_1");

            entity.HasOne(d => d.Language).WithMany(p => p.Students)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("students_ibfk_3");

            entity.HasOne(d => d.Province).WithMany(p => p.Students)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("students_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("students_ibfk_4");
        });

        modelBuilder.Entity<StudentsFlag>(entity =>
        {
            entity.HasKey(e => e.StudentsFlagId).HasName("PRIMARY");

            entity.ToTable("students_flags");

            entity.HasIndex(e => e.FlagId, "flag_id");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.StudentsFlagId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("students_flag_id");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.FlagId)
                .HasMaxLength(191)
                .HasColumnName("flag_id");
            entity.Property(e => e.StudentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Flag).WithMany(p => p.StudentsFlags)
                .HasForeignKey(d => d.FlagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_students_flags_flags");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsFlags)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_students_flags_students");

            entity.HasOne(d => d.User).WithMany(p => p.StudentsFlags)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_students_flags_users");
        });

        modelBuilder.Entity<TaxReceipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tax_receipts")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.EnrollmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_id");
            entity.Property(e => e.Type)
                .HasMaxLength(25)
                .HasColumnName("type");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.TaxReceipts)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tax_receipts_ibfk_1");
        });

        modelBuilder.Entity<TimeZone>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PRIMARY");

            entity.ToTable("time_zones");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("student_id");
            entity.Property(e => e.TimeZoneId)
                .HasMaxLength(191)
                .HasColumnName("time_zone_id")
                .UseCollation("ascii_general_ci")
                .HasCharSet("ascii");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("transactions");

            entity.HasIndex(e => e.Auto, "auto");

            entity.HasIndex(e => e.EnrollmentId, "enrollment_id");

            entity.HasIndex(e => e.ExtraCharge, "extra_charge");

            entity.HasIndex(e => e.ParentId, "parent_id");

            entity.HasIndex(e => e.PaymentMethodId, "payment_method_id");

            entity.HasIndex(e => e.Posted, "posted");

            entity.HasIndex(e => e.Reattempt, "reattempt");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.AttemptedAmount)
                .HasPrecision(10, 2)
                .HasColumnName("attempted_amount");
            entity.Property(e => e.AuthorizationCode)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("authorization_code")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Auto).HasColumnName("auto");
            entity.Property(e => e.Chargeback)
                .HasPrecision(10, 2)
                .HasColumnName("chargeback");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .HasColumnName("description")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.EnrollmentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("enrollment_id");
            entity.Property(e => e.ExtraCharge).HasColumnName("extra_charge");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Notified).HasColumnName("notified");
            entity.Property(e => e.OrderId)
                .HasMaxLength(99)
                .HasColumnName("order_id")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ParentId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("parent_id");
            entity.Property(e => e.PaymentMethodId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("payment_method_id");
            entity.Property(e => e.Posted).HasColumnName("posted");
            entity.Property(e => e.PostedDate)
                .HasColumnType("timestamp")
                .HasColumnName("posted_date");
            entity.Property(e => e.Reattempt).HasColumnName("reattempt");
            entity.Property(e => e.ReferenceNumber)
                .HasColumnName("reference_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.Refund)
                .HasPrecision(10, 2)
                .HasColumnName("refund");
            entity.Property(e => e.Response)
                .HasColumnType("text")
                .HasColumnName("response")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.ResponseCode)
                .HasColumnType("mediumint(4) unsigned")
                .HasColumnName("response_code");
            entity.Property(e => e.SettlementId).HasColumnName("settlement_id");
            entity.Property(e => e.Severity)
                .HasColumnType("int(11)")
                .HasColumnName("severity");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionNumber)
                .HasMaxLength(20)
                .HasColumnName("transaction_number")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.TransactionTime)
                .HasColumnType("time")
                .HasColumnName("transaction_time");
            entity.Property(e => e.TransactionType)
                .HasDefaultValueSql("'charge'")
                .HasColumnType("enum('charge','refund','chargeback','nsf fee','void')")
                .HasColumnName("transaction_type")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.UsdAmount)
                .HasPrecision(10, 2)
                .HasColumnName("USD_amount");
            entity.Property(e => e.UserId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("user_id");
            entity.Property(e => e.Voided).HasColumnName("voided");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.EnrollmentId)
                .HasConstraintName("transactions_ibfk_1");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("transactions_ibfk_4");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("transactions_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("transactions_ibfk_3");
        });

        modelBuilder.Entity<TransactionReattemptInfo>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transaction_reattempt_info");

            entity.Property(e => e.TransactionId)
                .ValueGeneratedNever()
                .HasColumnType("int(10) unsigned")
                .HasColumnName("transaction_id");
            entity.Property(e => e.Reattempts)
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("reattempts");
            entity.Property(e => e.Success).HasColumnName("success");

            entity.HasOne(d => d.Transaction).WithOne(p => p.TransactionReattemptInfo)
                .HasForeignKey<TransactionReattemptInfo>(d => d.TransactionId)
                .HasConstraintName("transaction_reattempt_info_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.AccountingPriv)
                .HasComment("modify, charge, and refund credit cards, print bank deposit sheets")
                .HasColumnName("accounting_priv");
            entity.Property(e => e.AdminPriv)
                .HasComment("add and delete users, modify user permissions")
                .HasColumnName("admin_priv");
            entity.Property(e => e.Created)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .HasColumnName("email_address");
            entity.Property(e => e.FirstName)
                .HasMaxLength(40)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(40)
                .HasColumnName("last_name");
            entity.Property(e => e.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("timestamp")
                .HasColumnName("modified");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Sex)
                .HasDefaultValueSql("'F'")
                .HasColumnType("enum('M','F')")
                .HasColumnName("sex");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
