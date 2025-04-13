USE [DataGuardXcoreCreate];

EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'   --����o�y�N�i�H:�R������
EXEC sp_MSForEachTable 'DELETE FROM ?' 							--�R���Ҧ��ƾ�
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL' 	--��_����



DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += 'DROP TABLE ' + QUOTENAME(TABLE_SCHEMA) + '.' + QUOTENAME(TABLE_NAME) + ';' 
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA <> 'sys';

EXEC sp_executesql @sql;