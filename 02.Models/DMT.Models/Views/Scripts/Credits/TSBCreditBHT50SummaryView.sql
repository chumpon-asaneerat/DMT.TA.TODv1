/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT50SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
