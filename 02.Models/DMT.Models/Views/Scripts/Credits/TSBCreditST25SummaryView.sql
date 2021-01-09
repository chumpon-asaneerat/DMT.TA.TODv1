/* Use in TSBCreditSummaryView */
CREATE VIEW TSBCreditST25SummaryView
AS
	SELECT TSB.TSBId
		 , TSB.TSBNameEN
		 , TSB.TSBNameTH

	  FROM TSB
