IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250310055614_mssql.local_migration_894'
)
BEGIN
    CREATE TABLE [SocialMedia] (
        [id] int NOT NULL IDENTITY,
        [social_media_name] nvarchar(max) NOT NULL,
        [social_media_link] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_SocialMedia] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250310055614_mssql.local_migration_894'
)
BEGIN
    CREATE TABLE [User_Account_Model] (
        [id] decimal(20,0) NOT NULL IDENTITY,
        [username] nvarchar(150) NOT NULL,
        [password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_User_Account_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250310055614_mssql.local_migration_894'
)
BEGIN
    CREATE TABLE [User_Information] (
        [id] int NOT NULL IDENTITY,
        [username] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [phone_number] nvarchar(max) NOT NULL,
        [first_name] nvarchar(max) NOT NULL,
        [last_name] nvarchar(max) NOT NULL,
        [profile_picture] nvarchar(max) NOT NULL,
        [bio] nvarchar(max) NOT NULL,
        [date_of_birth] datetime2 NOT NULL,
        [social_medias] nvarchar(max) NOT NULL,
        [nationality] nvarchar(max) NOT NULL,
        [isactive] bit NOT NULL,
        [authentationemail] nvarchar(max) NOT NULL,
        [authentationphonenumber] nvarchar(max) NOT NULL,
        [authentationauthenticatorapp] nvarchar(max) NOT NULL,
        [authentationsecurityquestions] nvarchar(max) NOT NULL,
        [authentationsecuritykey] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_User_Information] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250310055614_mssql.local_migration_894'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250310055614_mssql.local_migration_894', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407013715_mssql.local_migration_886'
)
BEGIN
    CREATE TABLE [Friend_Request_Send] (
        [id] bigint NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [username] nvarchar(max) NOT NULL,
        [send_time] datetime2 NOT NULL,
        [message] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Friend_Request_Send] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407013715_mssql.local_migration_886'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250407013715_mssql.local_migration_886', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    DROP TABLE [Friend_Request_Send];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    DROP TABLE [SocialMedia];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    DROP TABLE [User_Information];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    CREATE TABLE [Friend_Request_Send_Model] (
        [id] bigint NOT NULL IDENTITY,
        [name] nvarchar(max) NOT NULL,
        [username] nvarchar(max) NOT NULL,
        [send_time] datetime2 NOT NULL,
        [message] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Friend_Request_Send_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    CREATE TABLE [Group_Account_Model] (
        [id] decimal(20,0) NOT NULL IDENTITY,
        [username] nvarchar(max) NOT NULL,
        [members_username] nvarchar(max) NOT NULL,
        [admin_usernames] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Group_Account_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    CREATE TABLE [Group_Information_Model] (
        [id] decimal(20,0) NOT NULL IDENTITY,
        [group_name] nvarchar(max) NOT NULL,
        [group_description] nvarchar(max) NOT NULL,
        [Owner_username] nvarchar(max) NOT NULL,
        [group_picture] nvarchar(max) NOT NULL,
        [group_creation_date] datetime2 NOT NULL,
        [group_last_activity] datetime2 NOT NULL,
        [group_isactive] bit NOT NULL,
        [group_isdeleted] bit NOT NULL,
        [group_isprivate] bit NOT NULL,
        [group_isblocked] bit NOT NULL,
        [group_isarchived] bit NOT NULL,
        [group_ismuted] bit NOT NULL,
        [group_isreported] bit NOT NULL,
        [group_isdeletedbyadmin] bit NOT NULL,
        [group_isdeletedbyuser] bit NOT NULL,
        [group_isdeletedbybot] bit NOT NULL,
        [group_isdeletedbyowner] bit NOT NULL,
        [group_isdeletedbyother] bit NOT NULL,
        CONSTRAINT [PK_Group_Information_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    CREATE TABLE [Social_Media_Model] (
        [id] bigint NOT NULL IDENTITY,
        [social_media_name] nvarchar(max) NOT NULL,
        [social_media_link] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Social_Media_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    CREATE TABLE [User_Account_Settings_Model] (
        [id] decimal(20,0) NOT NULL IDENTITY,
        [username] nvarchar(max) NOT NULL,
        [theme] nvarchar(max) NOT NULL,
        [language] nvarchar(max) NOT NULL,
        [notification_settings] nvarchar(max) NOT NULL,
        [privacy_settings] nvarchar(max) NOT NULL,
        [security_settings] nvarchar(max) NOT NULL,
        [account_settings] nvarchar(max) NOT NULL,
        [app_settings] nvarchar(max) NOT NULL,
        [location_settings] nvarchar(max) NOT NULL,
        [data_settings] nvarchar(max) NOT NULL,
        [backup_settings] nvarchar(max) NOT NULL,
        [sync_settings] nvarchar(max) NOT NULL,
        [appearance_settings] nvarchar(max) NOT NULL,
        [accessibility_settings] nvarchar(max) NOT NULL,
        [device_settings] nvarchar(max) NOT NULL,
        [customization_settings] nvarchar(max) NOT NULL,
        [data_usage_settings] nvarchar(max) NOT NULL,
        [data_export_settings] nvarchar(max) NOT NULL,
        [data_import_settings] nvarchar(max) NOT NULL,
        [data_deletion_settings] nvarchar(max) NOT NULL,
        [data_backup_settings] nvarchar(max) NOT NULL,
        [data_restore_settings] nvarchar(max) NOT NULL,
        [data_sync_settings] nvarchar(max) NOT NULL,
        [data_sharing_settings] nvarchar(max) NOT NULL,
        [data_storage_settings] nvarchar(max) NOT NULL,
        [data_encryption_settings] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_User_Account_Settings_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    CREATE TABLE [User_Information_Model] (
        [id] decimal(20,0) NOT NULL IDENTITY,
        [username] nvarchar(max) NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [phone_number] nvarchar(max) NOT NULL,
        [first_name] nvarchar(max) NOT NULL,
        [last_name] nvarchar(max) NOT NULL,
        [profile_picture] nvarchar(max) NOT NULL,
        [bio] nvarchar(max) NOT NULL,
        [date_of_birth] datetime2 NOT NULL,
        [social_medias] nvarchar(max) NOT NULL,
        [nationality] nvarchar(max) NOT NULL,
        [isactive] bit NOT NULL,
        [authentationemail] nvarchar(max) NOT NULL,
        [authentationphonenumber] nvarchar(max) NOT NULL,
        [authentationauthenticatorapp] nvarchar(max) NOT NULL,
        [authentationsecurityquestions] nvarchar(max) NOT NULL,
        [authentationsecuritykey] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_User_Information_Model] PRIMARY KEY ([id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250407031235_mssql.local_migration_737'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250407031235_mssql.local_migration_737', N'9.0.0');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250414090128_mssql.local_migration_989'
)
BEGIN
    ALTER TABLE [User_Information_Model] ADD [educations] nvarchar(max) NOT NULL DEFAULT N'[]';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250414090128_mssql.local_migration_989'
)
BEGIN
    ALTER TABLE [User_Information_Model] ADD [websites] nvarchar(max) NOT NULL DEFAULT N'[]';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250414090128_mssql.local_migration_989'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250414090128_mssql.local_migration_989', N'9.0.0');
END;

COMMIT;
GO

