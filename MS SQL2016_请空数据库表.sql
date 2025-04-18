USE [DataGuardXCoreM1]
GO
/****** Object:  StoredProcedure [dbo].[sp_DropAllTablesAndFK]    Script Date: 18/1/2022 上午10:56:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[sp_DropAllTablesAndFK] --定义存储过程（无参）
AS
BEGIN

    SET NOCOUNT ON;

    ----------------先从最近创建的FK开始解除FK约束-------------
    DECLARE c0 CURSOR FOR
            SELECT S.name,T.name,F.name --获得架构名、子表名、FK名
             FROM sys.foreign_keys AS F
             INNER JOIN sys.tables AS T
             ON F.parent_object_id = T.object_id
             INNER JOIN SYS.schemas AS S
             ON T.schema_id = S.schema_id
             ORDER BY F.create_date DESC;--按时间大小降序排列，即从最近的创建的FK开始解除


    DECLARE @sch_name varchar(100)
            ,@childName varchar(100)
            ,@fk_Name varchar(100)
            ,@SQL VARCHAR(8000);

    OPEN c0;--执行游标指令并缓存结果于游标区域(内存)中

    FETCH NEXT FROM c0 INTO @sch_name,@childName,@fk_Name
    WHILE(@@FETCH_STATUS=0)
        BEGIN
            SET @SQL='ALTER TABLE '+@sch_name+'.'+@childName+' DROP CONSTRAINT '+@fk_Name;
            EXEC(@SQL);
            FETCH NEXT FROM c0 INTO @sch_name,@childName,@fk_Name;
        END

    CLOSE c0;--一定要关闭游标(实际上，是删除游标所占用的内存空间)，之后若想再使用，必须重新打开
    DEALLOCATE c0;--释放游标(其内存空间被释放)

    PRINT 'Drop foreign keys success!';
    -------------------------------------------------

    -------------已解除FK,可以直接删除所有表-------------
    DECLARE c1 CURSOR FOR--定义游标
        SELECT S.name,T.name         --获得用户定义的表的名称
        FROM sys.tables as T
        INNER JOIN sys.schemas as S
        ON T.schema_id = S.schema_id
        WHERE TYPE='U';

    DECLARE @tbName varchar(100);
    SET @SQL='DROP TABLE ';

    OPEN c1;--执行游标指令并缓存结果于游标区域(内存)中

    FETCH NEXT FROM c1 INTO @sch_name,@tbName--
    WHILE(@@FETCH_STATUS=0)
        BEGIN
            SET @SQL=@SQL +@sch_name+'.'+@tbName+',';

            FETCH NEXT FROM c1 INTO @sch_name,@tbName;
        END;
    CLOSE c1;--一定要关闭游标(实际上，是删除游标所占用的内存空间)，之后若想再使用，必须重新定义
    DEALLOCATE c1;--释放游标(其内存空间被释放)

    IF LEN(@SQL) > LEN('DROP TABLE ')
    BEGIN
        SET @SQL=LEFT(@SQL,LEN(@SQL)-1);--需要去掉最后一个的逗号
        EXEC(@SQL);
        PRINT 'Drop tables success!';
    END

    SET NOCOUNT OFF;

    PRINT 'Procedure done!';
END
 
