﻿<?xml version="1.0" encoding="utf-16"?><Process Version="1" Start="Start" Name="CashReimbursementProcess" Folder="McDonald.GAP.K2.Workflow" Desc=""><Acts><Act Name="Start" Desc="" Loc="200,10" Size="190,40" Max="false" Color="255,166,166,166" StrOpn="false" /><Act Name="FillApplicationActivity" Desc="Employee fills application for cash reimbursement process" Loc="448,144" Size="190,71" Max="true" Color="255,166,166,166" StrOpn="true"><Evt Name="ClientEvent" Desc="" Type="ClientEvent" EventType="SourceCode.Workflow.Design.ClientEvent" /></Act><Act Name="SupervisorApprovalActivity" Desc="Supervisor approves or declines the employee's application" Loc="128,128" Size="231,71" Max="true" Color="255,166,166,166" StrOpn="true"><Evt Name="ClientEvent" Desc="" Type="ClientEvent" EventType="SourceCode.Workflow.Design.ClientEvent" /></Act><Act Name="PrintAndSendActivity" Desc="" Loc="128,304" Size="225,71" Max="true" Color="255,166,166,166" StrOpn="true"><Evt Name="ServerEvent" Desc="" Type="ServerEvent" EventType="SourceCode.Workflow.Design.ServerEvent" /></Act><Act Name="SSCReceiveActivity" Desc="" Loc="128,432" Size="227,48" Max="true" Color="255,166,166,166" StrOpn="false"><Evt Name="ClientEvent" Desc="" Type="ClientEvent" EventType="SourceCode.Workflow.Design.ClientEvent" /></Act><Act Name="SSCApprovalActivity" Desc="" Loc="128,544" Size="227,71" Max="true" Color="255,166,166,166" StrOpn="true"><Evt Name="ClientEvent" Desc="" Type="ClientEvent" EventType="SourceCode.Workflow.Design.ClientEvent" /></Act><Act Name="PaymentActivity" Desc="" Loc="96,672" Size="190,48" Max="true" Color="255,166,166,166" StrOpn="false"><Evt Name="ServerEvent" Desc="" Type="ServerEvent" EventType="SourceCode.Workflow.Design.ServerEvent" /></Act><Act Name="RefundApplicationActivity" Desc="" Loc="384,672" Size="190,48" Max="true" Color="255,166,166,166" StrOpn="false"><Evt Name="ServerEvent" Desc="" Type="ServerEvent" EventType="SourceCode.Workflow.Design.ServerEvent" /></Act></Acts><Lines><Line Name="Submit" Color="255,26,85,39" Start="FillApplicationActivity" End="SupervisorApprovalActivity"><Anchor Start="Left" End="Right" Coords="446,191+359,191" /><Label Label="Submit" Loc="384,165" Rot="0" Pos="true" /></Line><Line Name="Approve" Color="255,26,85,39" Start="SupervisorApprovalActivity" End="PrintAndSendActivity"><Anchor Start="Down" End="Up" Coords="214,222+214,304" /><Label Label="Approve" Loc="149,261" Rot="0" Pos="true" /></Line><Line Name="Reject" Color="255,26,85,39" Start="SupervisorApprovalActivity" End="FillApplicationActivity"><Anchor Start="Down" End="Down" Coords="256,222+256,240+480,240+480,215" /><Label Label="Reject" Loc="379,246" Rot="0" Pos="true" /></Line><Line Name="DefaultLine1" Color="255,26,85,39" Start="PrintAndSendActivity" End="SSCReceiveActivity"><Anchor Start="Down" End="Up" Coords="223,398+223,432" /><Label Label="" Loc="317,365" Rot="0" Pos="false" /></Line><Line Name="Task Completed" Color="255,26,85,39" Start="SSCReceiveActivity" End="SSCApprovalActivity"><Anchor Start="Down" End="Up" Coords="224,503+224,544" /><Label Label="Task Completed" Loc="220,515" Rot="0" Pos="false" /></Line><Line Name="Approve1" Color="255,26,85,39" Start="SSCApprovalActivity" End="PaymentActivity"><Anchor Start="Down" End="Up" Coords="226,638+226,656+177,656+177,652+128,652+128,672" /><Label Label="Approve" Loc="166,628" Rot="90" Pos="true" /></Line><Line Name="Reject1" Color="255,26,85,39" Start="SSCApprovalActivity" End="RefundApplicationActivity"><Anchor Start="Down" End="Up" Coords="228,638+228,656+354,656+354,652+480,652+480,672" /><Label Label="Reject" Loc="381,627" Rot="90" Pos="false" /></Line><Line Name="Communicate" Color="255,26,85,39" Start="SSCApprovalActivity" End="FillApplicationActivity"><Anchor Start="Right" End="Right" Coords="356,576+657,576+657,174+638,174" /><Label Label="Communicate" Loc="624,379" Rot="90" Pos="true" /></Line><Line Name="DefaultLine2" Color="255,26,85,39" Start="Start" End="SupervisorApprovalActivity"><Anchor Start="Down" End="Up" Coords="257,51+257,128" /><Label Label="" Loc="257,88" Rot="0" Pos="false" /></Line><Line Name="Continue" Color="255,26,85,39" Start="SupervisorApprovalActivity" End="SupervisorApprovalActivity"><Anchor Start="Right" End="Up" Coords="360,178+378,178+378,108+288,108+288,128" /><Label Label="Continue" Loc="341,120" Rot="0" Pos="true" /></Line></Lines></Process>