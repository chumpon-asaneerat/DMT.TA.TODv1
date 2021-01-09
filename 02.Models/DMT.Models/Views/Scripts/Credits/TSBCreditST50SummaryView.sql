/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditST50SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
