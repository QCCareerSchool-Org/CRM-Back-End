// <copyright file="QcContext.cs" company="QC Career School">
// Copyright (c) QC Career School. All rights reserved.
// </copyright>

namespace CRM.Data;
namespace Configuration;

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

        new AffiliateIdConfiguration().Configure(modelBuilder.Entity<AffiliateId>());


        new BonusItemConfiguration().Configure(modelBuilder.Entity<BonusItem>());

        new BonusItemShipmentConfiguration().Configure(modelBuilder.Entity<BonusItemShipment>());

        new BonusItemsCourseConfiguration().Configure(modelBuilder.Entity<BonusItemsCourse>());

        new CardeasexmlResponseConfiguration().Configure(modelBuilder.Entity<CardeasexmlResponse>());

        new CardeasexmlTokenConfiguration().Configure(modelBuilder.Entity<CardeasexmlToken>());

        new CountryConfiguration().Configure(modelBuilder.Entity<Country>());

        new CountryCallingCodeConfiguration().Configure(modelBuilder.Entity<CountryCallingCode>());

        new CourseConfiguration().Configure(modelBuilder.Entity<Course>());

        new CurrencyConfiguration().Configure(modelBuilder.Entity<Currency>());

        new EmailMessageConfiguration().Configure(modelBuilder.Entity<EmailMessage>());

        new EmailMessageTypeConfiguration().Configure(modelBuilder.Entity<EmailMessageType>());

        new EnrollmentConfiguration().Configure(modelBuilder.Entity<Enrollment>());

        new EselectPlusResponseConfiguration().Configure(modelBuilder.Entity<EselectPlusResponse>());

        new EselectPlusTokenConfiguration().Configure(modelBuilder.Entity<EselectPlusToken>());

        new FailedTransactionConfiguration().Configure(modelBuilder.Entity<FailedTransaction>());

        new FlagConfiguration().Configure(modelBuilder.Entity<Flag>());

        new GeoLocationConfiguration().Configure(modelBuilder.Entity<GeoLocation>());

        new GlobalChequePostConfiguration().Configure(modelBuilder.Entity<GlobalChequePost>());

        new GlobalPaymentMethodConfiguration().Configure(modelBuilder.Entity<GlobalPaymentMethod>());

        new GlobalPaymentTypeConfiguration().Configure(modelBuilder.Entity<GlobalPaymentType>());

        new GlobalPaysafeTransactionConfiguration().Configure(modelBuilder.Entity<GlobalPaysafeTransaction>());

        new GlobalTransactionConfiguration().Configure(modelBuilder.Entity<GlobalTransaction>());

        new GlobalTransactionBreakdownConfiguration().Configure(modelBuilder.Entity<GlobalTransactionBreakdown>());

        new LanguageConfiguration().Configure(modelBuilder.Entity<Language>());

        new NoteConfiguration().Configure(modelBuilder.Entity<Note>());

        new PaymentMethodConfiguration().Configure(modelBuilder.Entity<PaymentMethod>());

        new PaymentTypeConfiguration().Configure(modelBuilder.Entity<PaymentType>());

        new PaysafeResponseConfiguration().Configure(modelBuilder.Entity<PaysafeResponse>());

        new PaysafeTokenConfiguration().Configure(modelBuilder.Entity<PaysafeToken>());

        new PriceConfiguration().Configure(modelBuilder.Entity<Price>());

        new ProvinceConfiguration().Configure(modelBuilder.Entity<Province>());

        new RefreshTokenConfiguration().Configure(modelBuilder.Entity<RefreshToken>());

        new SchoolConfiguration().Configure(modelBuilder.Entity<School>());

        new StudentConfiguration().Configure(modelBuilder.Entity<Student>());

        new StudentsFlagConfiguration().Configure(modelBuilder.Entity<StudentsFlag>());

        new TaxReceiptConfiguration().Configure(modelBuilder.Entity<TaxReceipt>());

        new TimeZoneConfiguration().Configure(modelBuilder.Entity<TimeZone>());

        new TransactionConfiguration().Configure(modelBuilder.Entity<Transaction>());

        new TransactionReattemptInfoConfiguration().Configure(modelBuilder.Entity<TransactionReattemptInfo>());

        new UserConfiguration().Configure(modelBuilder.Entity<User>());

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
