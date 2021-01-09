/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT100SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
