/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT1000SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
