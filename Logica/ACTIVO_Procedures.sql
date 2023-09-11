--region Drop Existing Procedures

IF OBJECT_ID(N'[dbo].[usp_InsertACTIVO]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertACTIVO]

IF OBJECT_ID(N'[dbo].[usp_UpdateACTIVO]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateACTIVO]

IF OBJECT_ID(N'[dbo].[usp_InsertUpdateACTIVO]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertUpdateACTIVO]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVO]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVO]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVO]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVO]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsAll]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndCOL_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndCOL_ID]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndCUS_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndCUS_ID]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndEMP_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndEMP_ID]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndEST_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID1]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndEST_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID2]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndEST_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID3]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndEST_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID4]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndGRU_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID3]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndGRU_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID4]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndGRU_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID1]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndGRU_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID2]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndMAR_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndMAR_ID]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndMOD_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndMOD_ID]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndPIS_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndPIS_ID]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUGE_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID3]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUGE_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID4]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUGE_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID1]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUGE_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID2]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUOR_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID3]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUOR_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID4]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUOR_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID1]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndUOR_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID2]

IF OBJECT_ID(N'[dbo].[usp_SelectACTIVOsByAndACT_CODBARRAS]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectACTIVOsByAndACT_CODBARRAS]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndCOL_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndCOL_ID]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndCUS_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndCUS_ID]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndEMP_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEMP_ID]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndEST_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID1]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndEST_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID2]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndEST_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID3]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndEST_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID4]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndGRU_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID3]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndGRU_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID4]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndGRU_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID1]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndGRU_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID2]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndMAR_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndMAR_ID]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndMOD_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndMOD_ID]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndPIS_ID]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndPIS_ID]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUGE_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID3]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUGE_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID4]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUGE_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID1]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUGE_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID2]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUOR_ID3]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID3]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUOR_ID4]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID4]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUOR_ID1]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID1]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndUOR_ID2]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID2]

IF OBJECT_ID(N'[dbo].[usp_DeleteACTIVOsByAndACT_CODBARRAS]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteACTIVOsByAndACT_CODBARRAS]

--endregion

GO

--region [dbo].[usp_InsertACTIVO]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertACTIVO]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertACTIVO]
	@ACT_IDPADRE int,
	@ACT_CODBARRAS varchar(150),
	@ACT_CODBARRASPADRE varchar(150),
	@ACT_SECUENCIAL varchar(150),
	@ACT_SECUENCIALPADRE varchar(150),
	@ACT_FECHAINVENTARIO smalldatetime,
	@ACT_FECHACREACION smalldatetime,
	@ACT_RESPONSABLES varchar(50),
	@ACT_CODIGO1 varchar(500),
	@ACT_CODIGO2 varchar(500),
	@ACT_CODIGO3 varchar(500),
	@ACT_CODIGO4 varchar(500),
	@ACT_ANIO int,
	@ACT_SERIE1 varchar(150),
	@ACT_SERIE2 varchar(250),
	@ACT_HOJA1 varchar(4),
	@ACT_HOJA2 varchar(4),
	@ACT_ESTRUCTURA1 int,
	@ACT_ESTRUCTURA2 int,
	@ACT_COMPONENTE1 int,
	@ACT_COMPONENTE2 int,
	@ACT_COMPONENTE3 int,
	@ACT_COMPONENTE4 int,
	@ACT_TIPO varchar(250),
	@ACT_OBSERVACIONES varchar(3000),
	@USERNAME varchar(100),
	@ACT_FOTO1 varchar(150),
	@ACT_FOTO2 varchar(150),
	@ACT_FOTO3 varchar(150),
	@ACT_CANTIDAD money,
	@ACT_ACTIVADO bit,
	@ACT_ELIMINADO bit,
	@ACT_DOC1 varchar(150),
	@ACT_DOC2 varchar(150),
	@EST_ID1 int,
	@EST_ID2 int,
	@EST_ID3 int,
	@EST_ID4 int,
	@GRU_ID1 int,
	@GRU_ID2 int,
	@GRU_ID3 int,
	@GRU_ID4 int,
	@UGE_ID1 int,
	@UGE_ID2 int,
	@UGE_ID3 int,
	@UGE_ID4 int,
	@UOR_ID1 int,
	@UOR_ID2 int,
	@UOR_ID3 int,
	@UOR_ID4 int,
	@CUS_ID int,
	@MAR_ID int,
	@MOD_ID int,
	@COL_ID int,
	@EMP_ID varchar(50),
	@PIS_ID int,
	@ACT_ID int OUTPUT
AS

SET NOCOUNT ON

INSERT INTO [dbo].[ACTIVO] (
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
) VALUES (
	@ACT_IDPADRE,
	@ACT_CODBARRAS,
	@ACT_CODBARRASPADRE,
	@ACT_SECUENCIAL,
	@ACT_SECUENCIALPADRE,
	@ACT_FECHAINVENTARIO,
	@ACT_FECHACREACION,
	@ACT_RESPONSABLES,
	@ACT_CODIGO1,
	@ACT_CODIGO2,
	@ACT_CODIGO3,
	@ACT_CODIGO4,
	@ACT_ANIO,
	@ACT_SERIE1,
	@ACT_SERIE2,
	@ACT_HOJA1,
	@ACT_HOJA2,
	@ACT_ESTRUCTURA1,
	@ACT_ESTRUCTURA2,
	@ACT_COMPONENTE1,
	@ACT_COMPONENTE2,
	@ACT_COMPONENTE3,
	@ACT_COMPONENTE4,
	@ACT_TIPO,
	@ACT_OBSERVACIONES,
	@USERNAME,
	@ACT_FOTO1,
	@ACT_FOTO2,
	@ACT_FOTO3,
	@ACT_CANTIDAD,
	@ACT_ACTIVADO,
	@ACT_ELIMINADO,
	@ACT_DOC1,
	@ACT_DOC2,
	@EST_ID1,
	@EST_ID2,
	@EST_ID3,
	@EST_ID4,
	@GRU_ID1,
	@GRU_ID2,
	@GRU_ID3,
	@GRU_ID4,
	@UGE_ID1,
	@UGE_ID2,
	@UGE_ID3,
	@UGE_ID4,
	@UOR_ID1,
	@UOR_ID2,
	@UOR_ID3,
	@UOR_ID4,
	@CUS_ID,
	@MAR_ID,
	@MOD_ID,
	@COL_ID,
	@EMP_ID,
	@PIS_ID
)

SET @ACT_ID = SCOPE_IDENTITY()

--endregion

GO

--region [dbo].[usp_UpdateACTIVO]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_UpdateACTIVO]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_UpdateACTIVO]
	@ACT_ID int,
	@ACT_IDPADRE int,
	@ACT_CODBARRAS varchar(150),
	@ACT_CODBARRASPADRE varchar(150),
	@ACT_SECUENCIAL varchar(150),
	@ACT_SECUENCIALPADRE varchar(150),
	@ACT_FECHAINVENTARIO smalldatetime,
	@ACT_FECHACREACION smalldatetime,
	@ACT_RESPONSABLES varchar(50),
	@ACT_CODIGO1 varchar(500),
	@ACT_CODIGO2 varchar(500),
	@ACT_CODIGO3 varchar(500),
	@ACT_CODIGO4 varchar(500),
	@ACT_ANIO int,
	@ACT_SERIE1 varchar(150),
	@ACT_SERIE2 varchar(250),
	@ACT_HOJA1 varchar(4),
	@ACT_HOJA2 varchar(4),
	@ACT_ESTRUCTURA1 int,
	@ACT_ESTRUCTURA2 int,
	@ACT_COMPONENTE1 int,
	@ACT_COMPONENTE2 int,
	@ACT_COMPONENTE3 int,
	@ACT_COMPONENTE4 int,
	@ACT_TIPO varchar(250),
	@ACT_OBSERVACIONES varchar(3000),
	@USERNAME varchar(100),
	@ACT_FOTO1 varchar(150),
	@ACT_FOTO2 varchar(150),
	@ACT_FOTO3 varchar(150),
	@ACT_CANTIDAD money,
	@ACT_ACTIVADO bit,
	@ACT_ELIMINADO bit,
	@ACT_DOC1 varchar(150),
	@ACT_DOC2 varchar(150),
	@EST_ID1 int,
	@EST_ID2 int,
	@EST_ID3 int,
	@EST_ID4 int,
	@GRU_ID1 int,
	@GRU_ID2 int,
	@GRU_ID3 int,
	@GRU_ID4 int,
	@UGE_ID1 int,
	@UGE_ID2 int,
	@UGE_ID3 int,
	@UGE_ID4 int,
	@UOR_ID1 int,
	@UOR_ID2 int,
	@UOR_ID3 int,
	@UOR_ID4 int,
	@CUS_ID int,
	@MAR_ID int,
	@MOD_ID int,
	@COL_ID int,
	@EMP_ID varchar(50),
	@PIS_ID int
AS

SET NOCOUNT ON

UPDATE [dbo].[ACTIVO] SET
	[ACT_IDPADRE] = @ACT_IDPADRE,
	[ACT_CODBARRAS] = @ACT_CODBARRAS,
	[ACT_CODBARRASPADRE] = @ACT_CODBARRASPADRE,
	[ACT_SECUENCIAL] = @ACT_SECUENCIAL,
	[ACT_SECUENCIALPADRE] = @ACT_SECUENCIALPADRE,
	[ACT_FECHAINVENTARIO] = @ACT_FECHAINVENTARIO,
	[ACT_FECHACREACION] = @ACT_FECHACREACION,
	[ACT_RESPONSABLES] = @ACT_RESPONSABLES,
	[ACT_CODIGO1] = @ACT_CODIGO1,
	[ACT_CODIGO2] = @ACT_CODIGO2,
	[ACT_CODIGO3] = @ACT_CODIGO3,
	[ACT_CODIGO4] = @ACT_CODIGO4,
	[ACT_ANIO] = @ACT_ANIO,
	[ACT_SERIE1] = @ACT_SERIE1,
	[ACT_SERIE2] = @ACT_SERIE2,
	[ACT_HOJA1] = @ACT_HOJA1,
	[ACT_HOJA2] = @ACT_HOJA2,
	[ACT_ESTRUCTURA1] = @ACT_ESTRUCTURA1,
	[ACT_ESTRUCTURA2] = @ACT_ESTRUCTURA2,
	[ACT_COMPONENTE1] = @ACT_COMPONENTE1,
	[ACT_COMPONENTE2] = @ACT_COMPONENTE2,
	[ACT_COMPONENTE3] = @ACT_COMPONENTE3,
	[ACT_COMPONENTE4] = @ACT_COMPONENTE4,
	[ACT_TIPO] = @ACT_TIPO,
	[ACT_OBSERVACIONES] = @ACT_OBSERVACIONES,
	[USERNAME] = @USERNAME,
	[ACT_FOTO1] = @ACT_FOTO1,
	[ACT_FOTO2] = @ACT_FOTO2,
	[ACT_FOTO3] = @ACT_FOTO3,
	[ACT_CANTIDAD] = @ACT_CANTIDAD,
	[ACT_ACTIVADO] = @ACT_ACTIVADO,
	[ACT_ELIMINADO] = @ACT_ELIMINADO,
	[ACT_DOC1] = @ACT_DOC1,
	[ACT_DOC2] = @ACT_DOC2,
	[EST_ID1] = @EST_ID1,
	[EST_ID2] = @EST_ID2,
	[EST_ID3] = @EST_ID3,
	[EST_ID4] = @EST_ID4,
	[GRU_ID1] = @GRU_ID1,
	[GRU_ID2] = @GRU_ID2,
	[GRU_ID3] = @GRU_ID3,
	[GRU_ID4] = @GRU_ID4,
	[UGE_ID1] = @UGE_ID1,
	[UGE_ID2] = @UGE_ID2,
	[UGE_ID3] = @UGE_ID3,
	[UGE_ID4] = @UGE_ID4,
	[UOR_ID1] = @UOR_ID1,
	[UOR_ID2] = @UOR_ID2,
	[UOR_ID3] = @UOR_ID3,
	[UOR_ID4] = @UOR_ID4,
	[CUS_ID] = @CUS_ID,
	[MAR_ID] = @MAR_ID,
	[MOD_ID] = @MOD_ID,
	[COL_ID] = @COL_ID,
	[EMP_ID] = @EMP_ID,
	[PIS_ID] = @PIS_ID
WHERE
	[ACT_ID] = @ACT_ID

--endregion

GO

--region [dbo].[usp_InsertUpdateACTIVO]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_InsertUpdateACTIVO]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_InsertUpdateACTIVO]
	@ACT_ID int,
	@ACT_IDPADRE int,
	@ACT_CODBARRAS varchar(150),
	@ACT_CODBARRASPADRE varchar(150),
	@ACT_SECUENCIAL varchar(150),
	@ACT_SECUENCIALPADRE varchar(150),
	@ACT_FECHAINVENTARIO smalldatetime,
	@ACT_FECHACREACION smalldatetime,
	@ACT_RESPONSABLES varchar(50),
	@ACT_CODIGO1 varchar(500),
	@ACT_CODIGO2 varchar(500),
	@ACT_CODIGO3 varchar(500),
	@ACT_CODIGO4 varchar(500),
	@ACT_ANIO int,
	@ACT_SERIE1 varchar(150),
	@ACT_SERIE2 varchar(250),
	@ACT_HOJA1 varchar(4),
	@ACT_HOJA2 varchar(4),
	@ACT_ESTRUCTURA1 int,
	@ACT_ESTRUCTURA2 int,
	@ACT_COMPONENTE1 int,
	@ACT_COMPONENTE2 int,
	@ACT_COMPONENTE3 int,
	@ACT_COMPONENTE4 int,
	@ACT_TIPO varchar(250),
	@ACT_OBSERVACIONES varchar(3000),
	@USERNAME varchar(100),
	@ACT_FOTO1 varchar(150),
	@ACT_FOTO2 varchar(150),
	@ACT_FOTO3 varchar(150),
	@ACT_CANTIDAD money,
	@ACT_ACTIVADO bit,
	@ACT_ELIMINADO bit,
	@ACT_DOC1 varchar(150),
	@ACT_DOC2 varchar(150),
	@EST_ID1 int,
	@EST_ID2 int,
	@EST_ID3 int,
	@EST_ID4 int,
	@GRU_ID1 int,
	@GRU_ID2 int,
	@GRU_ID3 int,
	@GRU_ID4 int,
	@UGE_ID1 int,
	@UGE_ID2 int,
	@UGE_ID3 int,
	@UGE_ID4 int,
	@UOR_ID1 int,
	@UOR_ID2 int,
	@UOR_ID3 int,
	@UOR_ID4 int,
	@CUS_ID int,
	@MAR_ID int,
	@MOD_ID int,
	@COL_ID int,
	@EMP_ID varchar(50),
	@PIS_ID int
AS

SET NOCOUNT ON

IF EXISTS(SELECT [ACT_ID] FROM [dbo].[ACTIVO] WHERE [ACT_ID] = @ACT_ID)
BEGIN
	UPDATE [dbo].[ACTIVO] SET
		[ACT_IDPADRE] = @ACT_IDPADRE,
		[ACT_CODBARRAS] = @ACT_CODBARRAS,
		[ACT_CODBARRASPADRE] = @ACT_CODBARRASPADRE,
		[ACT_SECUENCIAL] = @ACT_SECUENCIAL,
		[ACT_SECUENCIALPADRE] = @ACT_SECUENCIALPADRE,
		[ACT_FECHAINVENTARIO] = @ACT_FECHAINVENTARIO,
		[ACT_FECHACREACION] = @ACT_FECHACREACION,
		[ACT_RESPONSABLES] = @ACT_RESPONSABLES,
		[ACT_CODIGO1] = @ACT_CODIGO1,
		[ACT_CODIGO2] = @ACT_CODIGO2,
		[ACT_CODIGO3] = @ACT_CODIGO3,
		[ACT_CODIGO4] = @ACT_CODIGO4,
		[ACT_ANIO] = @ACT_ANIO,
		[ACT_SERIE1] = @ACT_SERIE1,
		[ACT_SERIE2] = @ACT_SERIE2,
		[ACT_HOJA1] = @ACT_HOJA1,
		[ACT_HOJA2] = @ACT_HOJA2,
		[ACT_ESTRUCTURA1] = @ACT_ESTRUCTURA1,
		[ACT_ESTRUCTURA2] = @ACT_ESTRUCTURA2,
		[ACT_COMPONENTE1] = @ACT_COMPONENTE1,
		[ACT_COMPONENTE2] = @ACT_COMPONENTE2,
		[ACT_COMPONENTE3] = @ACT_COMPONENTE3,
		[ACT_COMPONENTE4] = @ACT_COMPONENTE4,
		[ACT_TIPO] = @ACT_TIPO,
		[ACT_OBSERVACIONES] = @ACT_OBSERVACIONES,
		[USERNAME] = @USERNAME,
		[ACT_FOTO1] = @ACT_FOTO1,
		[ACT_FOTO2] = @ACT_FOTO2,
		[ACT_FOTO3] = @ACT_FOTO3,
		[ACT_CANTIDAD] = @ACT_CANTIDAD,
		[ACT_ACTIVADO] = @ACT_ACTIVADO,
		[ACT_ELIMINADO] = @ACT_ELIMINADO,
		[ACT_DOC1] = @ACT_DOC1,
		[ACT_DOC2] = @ACT_DOC2,
		[EST_ID1] = @EST_ID1,
		[EST_ID2] = @EST_ID2,
		[EST_ID3] = @EST_ID3,
		[EST_ID4] = @EST_ID4,
		[GRU_ID1] = @GRU_ID1,
		[GRU_ID2] = @GRU_ID2,
		[GRU_ID3] = @GRU_ID3,
		[GRU_ID4] = @GRU_ID4,
		[UGE_ID1] = @UGE_ID1,
		[UGE_ID2] = @UGE_ID2,
		[UGE_ID3] = @UGE_ID3,
		[UGE_ID4] = @UGE_ID4,
		[UOR_ID1] = @UOR_ID1,
		[UOR_ID2] = @UOR_ID2,
		[UOR_ID3] = @UOR_ID3,
		[UOR_ID4] = @UOR_ID4,
		[CUS_ID] = @CUS_ID,
		[MAR_ID] = @MAR_ID,
		[MOD_ID] = @MOD_ID,
		[COL_ID] = @COL_ID,
		[EMP_ID] = @EMP_ID,
		[PIS_ID] = @PIS_ID
	WHERE
		[ACT_ID] = @ACT_ID
END
ELSE
BEGIN
	INSERT INTO [dbo].[ACTIVO] (
		[ACT_ID],
		[ACT_IDPADRE],
		[ACT_CODBARRAS],
		[ACT_CODBARRASPADRE],
		[ACT_SECUENCIAL],
		[ACT_SECUENCIALPADRE],
		[ACT_FECHAINVENTARIO],
		[ACT_FECHACREACION],
		[ACT_RESPONSABLES],
		[ACT_CODIGO1],
		[ACT_CODIGO2],
		[ACT_CODIGO3],
		[ACT_CODIGO4],
		[ACT_ANIO],
		[ACT_SERIE1],
		[ACT_SERIE2],
		[ACT_HOJA1],
		[ACT_HOJA2],
		[ACT_ESTRUCTURA1],
		[ACT_ESTRUCTURA2],
		[ACT_COMPONENTE1],
		[ACT_COMPONENTE2],
		[ACT_COMPONENTE3],
		[ACT_COMPONENTE4],
		[ACT_TIPO],
		[ACT_OBSERVACIONES],
		[USERNAME],
		[ACT_FOTO1],
		[ACT_FOTO2],
		[ACT_FOTO3],
		[ACT_CANTIDAD],
		[ACT_ACTIVADO],
		[ACT_ELIMINADO],
		[ACT_DOC1],
		[ACT_DOC2],
		[EST_ID1],
		[EST_ID2],
		[EST_ID3],
		[EST_ID4],
		[GRU_ID1],
		[GRU_ID2],
		[GRU_ID3],
		[GRU_ID4],
		[UGE_ID1],
		[UGE_ID2],
		[UGE_ID3],
		[UGE_ID4],
		[UOR_ID1],
		[UOR_ID2],
		[UOR_ID3],
		[UOR_ID4],
		[CUS_ID],
		[MAR_ID],
		[MOD_ID],
		[COL_ID],
		[EMP_ID],
		[PIS_ID]
	) VALUES (
		@ACT_ID,
		@ACT_IDPADRE,
		@ACT_CODBARRAS,
		@ACT_CODBARRASPADRE,
		@ACT_SECUENCIAL,
		@ACT_SECUENCIALPADRE,
		@ACT_FECHAINVENTARIO,
		@ACT_FECHACREACION,
		@ACT_RESPONSABLES,
		@ACT_CODIGO1,
		@ACT_CODIGO2,
		@ACT_CODIGO3,
		@ACT_CODIGO4,
		@ACT_ANIO,
		@ACT_SERIE1,
		@ACT_SERIE2,
		@ACT_HOJA1,
		@ACT_HOJA2,
		@ACT_ESTRUCTURA1,
		@ACT_ESTRUCTURA2,
		@ACT_COMPONENTE1,
		@ACT_COMPONENTE2,
		@ACT_COMPONENTE3,
		@ACT_COMPONENTE4,
		@ACT_TIPO,
		@ACT_OBSERVACIONES,
		@USERNAME,
		@ACT_FOTO1,
		@ACT_FOTO2,
		@ACT_FOTO3,
		@ACT_CANTIDAD,
		@ACT_ACTIVADO,
		@ACT_ELIMINADO,
		@ACT_DOC1,
		@ACT_DOC2,
		@EST_ID1,
		@EST_ID2,
		@EST_ID3,
		@EST_ID4,
		@GRU_ID1,
		@GRU_ID2,
		@GRU_ID3,
		@GRU_ID4,
		@UGE_ID1,
		@UGE_ID2,
		@UGE_ID3,
		@UGE_ID4,
		@UOR_ID1,
		@UOR_ID2,
		@UOR_ID3,
		@UOR_ID4,
		@CUS_ID,
		@MAR_ID,
		@MOD_ID,
		@COL_ID,
		@EMP_ID,
		@PIS_ID
	)
END

--endregion

GO

--region [dbo].[usp_DeleteACTIVO]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVO]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVO]
	@ACT_ID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[ACT_ID] = @ACT_ID

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndCOL_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndCOL_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndCOL_ID]
	@COL_ID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[COL_ID] = @COL_ID

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndCUS_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndCUS_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndCUS_ID]
	@CUS_ID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[CUS_ID] = @CUS_ID

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndEMP_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndEMP_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEMP_ID]
	@EMP_ID varchar(50)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[EMP_ID] = @EMP_ID

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndEST_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndEST_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID1]
	@EST_ID1 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[EST_ID1] = @EST_ID1

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndEST_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndEST_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID2]
	@EST_ID2 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[EST_ID2] = @EST_ID2

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndEST_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndEST_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID3]
	@EST_ID3 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[EST_ID3] = @EST_ID3

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndEST_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndEST_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndEST_ID4]
	@EST_ID4 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[EST_ID4] = @EST_ID4

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndGRU_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndGRU_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID3]
	@GRU_ID3 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[GRU_ID3] = @GRU_ID3

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndGRU_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndGRU_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID4]
	@GRU_ID4 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[GRU_ID4] = @GRU_ID4

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndGRU_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndGRU_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID1]
	@GRU_ID1 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[GRU_ID1] = @GRU_ID1

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndGRU_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndGRU_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndGRU_ID2]
	@GRU_ID2 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[GRU_ID2] = @GRU_ID2

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndMAR_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndMAR_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndMAR_ID]
	@MAR_ID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[MAR_ID] = @MAR_ID

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndMOD_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndMOD_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndMOD_ID]
	@MOD_ID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[MOD_ID] = @MOD_ID

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndPIS_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndPIS_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndPIS_ID]
	@PIS_ID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[PIS_ID] = @PIS_ID

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUGE_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUGE_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID3]
	@UGE_ID3 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UGE_ID3] = @UGE_ID3

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUGE_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUGE_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID4]
	@UGE_ID4 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UGE_ID4] = @UGE_ID4

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUGE_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUGE_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID1]
	@UGE_ID1 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UGE_ID1] = @UGE_ID1

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUGE_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUGE_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUGE_ID2]
	@UGE_ID2 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UGE_ID2] = @UGE_ID2

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUOR_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUOR_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID3]
	@UOR_ID3 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UOR_ID3] = @UOR_ID3

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUOR_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUOR_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID4]
	@UOR_ID4 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UOR_ID4] = @UOR_ID4

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUOR_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUOR_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID1]
	@UOR_ID1 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UOR_ID1] = @UOR_ID1

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndUOR_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndUOR_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndUOR_ID2]
	@UOR_ID2 int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[UOR_ID2] = @UOR_ID2

GO

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsByAndACT_CODBARRAS]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsByAndACT_CODBARRAS]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsByAndACT_CODBARRAS]
	@ACT_CODBARRAS varchar(150)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[ACTIVO]
WHERE
	[ACT_CODBARRAS] = @ACT_CODBARRAS

--endregion

GO

--region [dbo].[usp_DeleteACTIVOsDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_DeleteACTIVOsDynamic]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_DeleteACTIVOsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[ACTIVO]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion

GO

--region [dbo].[usp_SelectACTIVO]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVO]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVO]
	@ACT_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[ACT_ID] = @ACT_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndCOL_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndCOL_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndCOL_ID]
	@COL_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[COL_ID] = @COL_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndCUS_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndCUS_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndCUS_ID]
	@CUS_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[CUS_ID] = @CUS_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndEMP_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndEMP_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndEMP_ID]
	@EMP_ID varchar(50)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[EMP_ID] = @EMP_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndEST_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndEST_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID1]
	@EST_ID1 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[EST_ID1] = @EST_ID1

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndEST_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndEST_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID2]
	@EST_ID2 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[EST_ID2] = @EST_ID2

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndEST_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndEST_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID3]
	@EST_ID3 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[EST_ID3] = @EST_ID3

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndEST_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndEST_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndEST_ID4]
	@EST_ID4 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[EST_ID4] = @EST_ID4

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndGRU_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndGRU_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID3]
	@GRU_ID3 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[GRU_ID3] = @GRU_ID3

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndGRU_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndGRU_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID4]
	@GRU_ID4 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[GRU_ID4] = @GRU_ID4

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndGRU_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndGRU_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID1]
	@GRU_ID1 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[GRU_ID1] = @GRU_ID1

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndGRU_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndGRU_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndGRU_ID2]
	@GRU_ID2 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[GRU_ID2] = @GRU_ID2

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndMAR_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndMAR_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndMAR_ID]
	@MAR_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[MAR_ID] = @MAR_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndMOD_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndMOD_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndMOD_ID]
	@MOD_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[MOD_ID] = @MOD_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndPIS_ID]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndPIS_ID]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndPIS_ID]
	@PIS_ID int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[PIS_ID] = @PIS_ID

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUGE_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUGE_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID3]
	@UGE_ID3 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UGE_ID3] = @UGE_ID3

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUGE_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUGE_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID4]
	@UGE_ID4 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UGE_ID4] = @UGE_ID4

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUGE_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUGE_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID1]
	@UGE_ID1 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UGE_ID1] = @UGE_ID1

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUGE_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUGE_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUGE_ID2]
	@UGE_ID2 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UGE_ID2] = @UGE_ID2

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUOR_ID3]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUOR_ID3]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID3]
	@UOR_ID3 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UOR_ID3] = @UOR_ID3

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUOR_ID4]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUOR_ID4]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID4]
	@UOR_ID4 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UOR_ID4] = @UOR_ID4

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUOR_ID1]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUOR_ID1]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID1]
	@UOR_ID1 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UOR_ID1] = @UOR_ID1

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndUOR_ID2]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndUOR_ID2]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndUOR_ID2]
	@UOR_ID2 int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[UOR_ID2] = @UOR_ID2

--endregion

GO

--region [dbo].[usp_SelectACTIVOsByAndACT_CODBARRAS]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsByAndACT_CODBARRAS]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsByAndACT_CODBARRAS]
	@ACT_CODBARRAS varchar(150)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	[ACT_CODBARRAS] = @ACT_CODBARRAS

--endregion

GO

--region [dbo].[usp_SelectACTIVOsDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsDynamic]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion

GO

--region [dbo].[usp_SelectACTIVOsAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsAll]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]

--endregion

GO

--region [dbo].[usp_SelectACTIVOsPaged]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   Gabriel Baldeon using CodeSmith 5.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[usp_SelectACTIVOsPaged]
-- Date Generated: martes, 24 de agosto de 2010
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[usp_SelectACTIVOsPaged]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ACT_ID],
	[ACT_IDPADRE],
	[ACT_CODBARRAS],
	[ACT_CODBARRASPADRE],
	[ACT_SECUENCIAL],
	[ACT_SECUENCIALPADRE],
	[ACT_FECHAINVENTARIO],
	[ACT_FECHACREACION],
	[ACT_RESPONSABLES],
	[ACT_CODIGO1],
	[ACT_CODIGO2],
	[ACT_CODIGO3],
	[ACT_CODIGO4],
	[ACT_ANIO],
	[ACT_SERIE1],
	[ACT_SERIE2],
	[ACT_HOJA1],
	[ACT_HOJA2],
	[ACT_ESTRUCTURA1],
	[ACT_ESTRUCTURA2],
	[ACT_COMPONENTE1],
	[ACT_COMPONENTE2],
	[ACT_COMPONENTE3],
	[ACT_COMPONENTE4],
	[ACT_TIPO],
	[ACT_OBSERVACIONES],
	[USERNAME],
	[ACT_FOTO1],
	[ACT_FOTO2],
	[ACT_FOTO3],
	[ACT_CANTIDAD],
	[ACT_ACTIVADO],
	[ACT_ELIMINADO],
	[ACT_DOC1],
	[ACT_DOC2],
	[EST_ID1],
	[EST_ID2],
	[EST_ID3],
	[EST_ID4],
	[GRU_ID1],
	[GRU_ID2],
	[GRU_ID3],
	[GRU_ID4],
	[UGE_ID1],
	[UGE_ID2],
	[UGE_ID3],
	[UGE_ID4],
	[UOR_ID1],
	[UOR_ID2],
	[UOR_ID3],
	[UOR_ID4],
	[CUS_ID],
	[MAR_ID],
	[MOD_ID],
	[COL_ID],
	[EMP_ID],
	[PIS_ID]
FROM
	[dbo].[ACTIVO]

--endregion

GO

