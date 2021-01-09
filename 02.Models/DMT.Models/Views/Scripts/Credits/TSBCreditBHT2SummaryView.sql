/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditBHT2SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
