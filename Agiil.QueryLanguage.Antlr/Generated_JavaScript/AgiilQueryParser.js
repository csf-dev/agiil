// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/Tools/../AgiilQuery.g4 by ANTLR 4.7.1
// jshint ignore: start
var antlr4 = require('antlr4/index');
var AgiilQueryVisitor = require('./AgiilQueryVisitor').AgiilQueryVisitor;

var grammarFileName = "AgiilQuery.g4";

var serializedATN = ["\u0003\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964",
    "\u0003\u0011o\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004\t",
    "\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0004\u0007\t\u0007\u0004",
    "\b\t\b\u0004\t\t\t\u0004\n\t\n\u0004\u000b\t\u000b\u0004\f\t\f\u0004",
    "\r\t\r\u0004\u000e\t\u000e\u0004\u000f\t\u000f\u0003\u0002\u0005\u0002",
    " \n\u0002\u0003\u0002\u0005\u0002#\n\u0002\u0003\u0002\u0003\u0002\u0003",
    "\u0003\u0003\u0003\u0005\u0003)\n\u0003\u0003\u0003\u0007\u0003,\n\u0003",
    "\f\u0003\u000e\u0003/\u000b\u0003\u0003\u0004\u0003\u0004\u0005\u0004",
    "3\n\u0004\u0003\u0005\u0003\u0005\u0003\u0005\u0003\u0005\u0003\u0006",
    "\u0003\u0006\u0003\u0006\u0003\u0007\u0003\u0007\u0003\u0007\u0003\u0007",
    "\u0005\u0007@\n\u0007\u0003\u0007\u0005\u0007C\n\u0007\u0003\b\u0003",
    "\b\u0003\t\u0003\t\u0003\n\u0005\nJ\n\n\u0003\n\u0003\n\u0003\u000b",
    "\u0003\u000b\u0003\f\u0003\f\u0005\fR\n\f\u0003\r\u0003\r\u0003\r\u0003",
    "\r\u0003\r\u0006\rY\n\r\r\r\u000e\rZ\u0003\r\u0005\r^\n\r\u0003\u000e",
    "\u0003\u000e\u0003\u000e\u0003\u000e\u0003\u000e\u0003\u000f\u0003\u000f",
    "\u0003\u000f\u0007\u000fh\n\u000f\f\u000f\u000e\u000fk\u000b\u000f\u0005",
    "\u000fm\n\u000f\u0003\u000f\u0002\u0002\u0010\u0002\u0004\u0006\b\n",
    "\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a\u001c\u0002\u0004\u0003",
    "\u0002\f\r\u0004\u0002\u0006\b\u000e\u000e\u0002q\u0002\u001f\u0003",
    "\u0002\u0002\u0002\u0004&\u0003\u0002\u0002\u0002\u00062\u0003\u0002",
    "\u0002\u0002\b4\u0003\u0002\u0002\u0002\n8\u0003\u0002\u0002\u0002\f",
    "B\u0003\u0002\u0002\u0002\u000eD\u0003\u0002\u0002\u0002\u0010F\u0003",
    "\u0002\u0002\u0002\u0012I\u0003\u0002\u0002\u0002\u0014M\u0003\u0002",
    "\u0002\u0002\u0016Q\u0003\u0002\u0002\u0002\u0018]\u0003\u0002\u0002",
    "\u0002\u001a_\u0003\u0002\u0002\u0002\u001cl\u0003\u0002\u0002\u0002",
    "\u001e \u0007\u0003\u0002\u0002\u001f\u001e\u0003\u0002\u0002\u0002",
    "\u001f \u0003\u0002\u0002\u0002 \"\u0003\u0002\u0002\u0002!#\u0005\u0004",
    "\u0003\u0002\"!\u0003\u0002\u0002\u0002\"#\u0003\u0002\u0002\u0002#",
    "$\u0003\u0002\u0002\u0002$%\u0007\u0002\u0002\u0003%\u0003\u0003\u0002",
    "\u0002\u0002&-\u0005\u0006\u0004\u0002\')\u0005\u000e\b\u0002(\'\u0003",
    "\u0002\u0002\u0002()\u0003\u0002\u0002\u0002)*\u0003\u0002\u0002\u0002",
    "*,\u0005\u0006\u0004\u0002+(\u0003\u0002\u0002\u0002,/\u0003\u0002\u0002",
    "\u0002-+\u0003\u0002\u0002\u0002-.\u0003\u0002\u0002\u0002.\u0005\u0003",
    "\u0002\u0002\u0002/-\u0003\u0002\u0002\u000203\u0005\n\u0006\u00021",
    "3\u0005\b\u0005\u000220\u0003\u0002\u0002\u000221\u0003\u0002\u0002",
    "\u00023\u0007\u0003\u0002\u0002\u000245\u0007\u0004\u0002\u000256\u0005",
    "\u0004\u0003\u000267\u0007\u0005\u0002\u00027\t\u0003\u0002\u0002\u0002",
    "89\u0005\u0010\t\u00029:\u0005\f\u0007\u0002:\u000b\u0003\u0002\u0002",
    "\u0002;<\u0005\u0012\n\u0002<=\u0005\u0016\f\u0002=C\u0003\u0002\u0002",
    "\u0002>@\u0007\u000b\u0002\u0002?>\u0003\u0002\u0002\u0002?@\u0003\u0002",
    "\u0002\u0002@A\u0003\u0002\u0002\u0002AC\u0005\u001a\u000e\u0002B;\u0003",
    "\u0002\u0002\u0002B?\u0003\u0002\u0002\u0002C\r\u0003\u0002\u0002\u0002",
    "DE\t\u0002\u0002\u0002E\u000f\u0003\u0002\u0002\u0002FG\u0007\u000e",
    "\u0002\u0002G\u0011\u0003\u0002\u0002\u0002HJ\u0007\u000b\u0002\u0002",
    "IH\u0003\u0002\u0002\u0002IJ\u0003\u0002\u0002\u0002JK\u0003\u0002\u0002",
    "\u0002KL\u0005\u0014\u000b\u0002L\u0013\u0003\u0002\u0002\u0002MN\t",
    "\u0003\u0002\u0002N\u0015\u0003\u0002\u0002\u0002OR\u0005\u0018\r\u0002",
    "PR\u0005\u001a\u000e\u0002QO\u0003\u0002\u0002\u0002QP\u0003\u0002\u0002",
    "\u0002R\u0017\u0003\u0002\u0002\u0002S^\u0007\u000e\u0002\u0002T^\u0007",
    "\u000b\u0002\u0002U^\u0007\f\u0002\u0002V^\u0007\r\u0002\u0002WY\u0007",
    "\u000f\u0002\u0002XW\u0003\u0002\u0002\u0002YZ\u0003\u0002\u0002\u0002",
    "ZX\u0003\u0002\u0002\u0002Z[\u0003\u0002\u0002\u0002[^\u0003\u0002\u0002",
    "\u0002\\^\u0007\u0010\u0002\u0002]S\u0003\u0002\u0002\u0002]T\u0003",
    "\u0002\u0002\u0002]U\u0003\u0002\u0002\u0002]V\u0003\u0002\u0002\u0002",
    "]X\u0003\u0002\u0002\u0002]\\\u0003\u0002\u0002\u0002^\u0019\u0003\u0002",
    "\u0002\u0002_`\u0007\u000e\u0002\u0002`a\u0007\u0004\u0002\u0002ab\u0005",
    "\u001c\u000f\u0002bc\u0007\u0005\u0002\u0002c\u001b\u0003\u0002\u0002",
    "\u0002di\u0005\u0016\f\u0002ef\u0007\t\u0002\u0002fh\u0005\u0016\f\u0002",
    "ge\u0003\u0002\u0002\u0002hk\u0003\u0002\u0002\u0002ig\u0003\u0002\u0002",
    "\u0002ij\u0003\u0002\u0002\u0002jm\u0003\u0002\u0002\u0002ki\u0003\u0002",
    "\u0002\u0002ld\u0003\u0002\u0002\u0002lm\u0003\u0002\u0002\u0002m\u001d",
    "\u0003\u0002\u0002\u0002\u000f\u001f\"(-2?BIQZ]il"].join("");


var atn = new antlr4.atn.ATNDeserializer().deserialize(serializedATN);

var decisionsToDFA = atn.decisionToState.map( function(ds, index) { return new antlr4.dfa.DFA(ds, index); });

var sharedContextCache = new antlr4.PredictionContextCache();

var literalNames = [ null, "'\uFEFF'", "'('", "')'", "'='", "'!='", "'~'", 
                     "','" ];

var symbolicNames = [ null, "BOM", "OPENPAREN", "CLOSEPAREN", "EQUALS", 
                      "NOTEQUALS", "TILDE", "COMMA", "WHITESPACE", "NOT", 
                      "AND", "OR", "NAME", "WORD", "QUOTEDVALUE", "ANY" ];

var ruleNames =  [ "criteria", "logicalcriteriagroups", "criterionorgroup", 
                   "criteriagroup", "criterion", "elementtest", "logicalcombination", 
                   "element", "predicate", "predicatename", "value", "constantvalue", 
                   "functioninvocation", "functionparameters" ];

function AgiilQueryParser (input) {
	antlr4.Parser.call(this, input);
    this._interp = new antlr4.atn.ParserATNSimulator(this, atn, decisionsToDFA, sharedContextCache);
    this.ruleNames = ruleNames;
    this.literalNames = literalNames;
    this.symbolicNames = symbolicNames;
    return this;
}

AgiilQueryParser.prototype = Object.create(antlr4.Parser.prototype);
AgiilQueryParser.prototype.constructor = AgiilQueryParser;

Object.defineProperty(AgiilQueryParser.prototype, "atn", {
	get : function() {
		return atn;
	}
});

AgiilQueryParser.EOF = antlr4.Token.EOF;
AgiilQueryParser.BOM = 1;
AgiilQueryParser.OPENPAREN = 2;
AgiilQueryParser.CLOSEPAREN = 3;
AgiilQueryParser.EQUALS = 4;
AgiilQueryParser.NOTEQUALS = 5;
AgiilQueryParser.TILDE = 6;
AgiilQueryParser.COMMA = 7;
AgiilQueryParser.WHITESPACE = 8;
AgiilQueryParser.NOT = 9;
AgiilQueryParser.AND = 10;
AgiilQueryParser.OR = 11;
AgiilQueryParser.NAME = 12;
AgiilQueryParser.WORD = 13;
AgiilQueryParser.QUOTEDVALUE = 14;
AgiilQueryParser.ANY = 15;

AgiilQueryParser.RULE_criteria = 0;
AgiilQueryParser.RULE_logicalcriteriagroups = 1;
AgiilQueryParser.RULE_criterionorgroup = 2;
AgiilQueryParser.RULE_criteriagroup = 3;
AgiilQueryParser.RULE_criterion = 4;
AgiilQueryParser.RULE_elementtest = 5;
AgiilQueryParser.RULE_logicalcombination = 6;
AgiilQueryParser.RULE_element = 7;
AgiilQueryParser.RULE_predicate = 8;
AgiilQueryParser.RULE_predicatename = 9;
AgiilQueryParser.RULE_value = 10;
AgiilQueryParser.RULE_constantvalue = 11;
AgiilQueryParser.RULE_functioninvocation = 12;
AgiilQueryParser.RULE_functionparameters = 13;

function CriteriaContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_criteria;
    return this;
}

CriteriaContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
CriteriaContext.prototype.constructor = CriteriaContext;

CriteriaContext.prototype.EOF = function() {
    return this.getToken(AgiilQueryParser.EOF, 0);
};

CriteriaContext.prototype.BOM = function() {
    return this.getToken(AgiilQueryParser.BOM, 0);
};

CriteriaContext.prototype.logicalcriteriagroups = function() {
    return this.getTypedRuleContext(LogicalcriteriagroupsContext,0);
};

CriteriaContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitCriteria(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.CriteriaContext = CriteriaContext;

AgiilQueryParser.prototype.criteria = function() {

    var localctx = new CriteriaContext(this, this._ctx, this.state);
    this.enterRule(localctx, 0, AgiilQueryParser.RULE_criteria);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 29;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.BOM) {
            this.state = 28;
            this.match(AgiilQueryParser.BOM);
        }

        this.state = 32;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.OPENPAREN || _la===AgiilQueryParser.NAME) {
            this.state = 31;
            this.logicalcriteriagroups();
        }

        this.state = 34;
        this.match(AgiilQueryParser.EOF);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function LogicalcriteriagroupsContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_logicalcriteriagroups;
    return this;
}

LogicalcriteriagroupsContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
LogicalcriteriagroupsContext.prototype.constructor = LogicalcriteriagroupsContext;

LogicalcriteriagroupsContext.prototype.criterionorgroup = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(CriterionorgroupContext);
    } else {
        return this.getTypedRuleContext(CriterionorgroupContext,i);
    }
};

LogicalcriteriagroupsContext.prototype.logicalcombination = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(LogicalcombinationContext);
    } else {
        return this.getTypedRuleContext(LogicalcombinationContext,i);
    }
};

LogicalcriteriagroupsContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitLogicalcriteriagroups(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.LogicalcriteriagroupsContext = LogicalcriteriagroupsContext;

AgiilQueryParser.prototype.logicalcriteriagroups = function() {

    var localctx = new LogicalcriteriagroupsContext(this, this._ctx, this.state);
    this.enterRule(localctx, 2, AgiilQueryParser.RULE_logicalcriteriagroups);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 36;
        this.criterionorgroup();
        this.state = 43;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.OPENPAREN) | (1 << AgiilQueryParser.AND) | (1 << AgiilQueryParser.OR) | (1 << AgiilQueryParser.NAME))) !== 0)) {
            this.state = 38;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===AgiilQueryParser.AND || _la===AgiilQueryParser.OR) {
                this.state = 37;
                this.logicalcombination();
            }

            this.state = 40;
            this.criterionorgroup();
            this.state = 45;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function CriterionorgroupContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_criterionorgroup;
    return this;
}

CriterionorgroupContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
CriterionorgroupContext.prototype.constructor = CriterionorgroupContext;

CriterionorgroupContext.prototype.criterion = function() {
    return this.getTypedRuleContext(CriterionContext,0);
};

CriterionorgroupContext.prototype.criteriagroup = function() {
    return this.getTypedRuleContext(CriteriagroupContext,0);
};

CriterionorgroupContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitCriterionorgroup(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.CriterionorgroupContext = CriterionorgroupContext;

AgiilQueryParser.prototype.criterionorgroup = function() {

    var localctx = new CriterionorgroupContext(this, this._ctx, this.state);
    this.enterRule(localctx, 4, AgiilQueryParser.RULE_criterionorgroup);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 48;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.NAME:
            this.state = 46;
            this.criterion();
            break;
        case AgiilQueryParser.OPENPAREN:
            this.state = 47;
            this.criteriagroup();
            break;
        default:
            throw new antlr4.error.NoViableAltException(this);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function CriteriagroupContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_criteriagroup;
    return this;
}

CriteriagroupContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
CriteriagroupContext.prototype.constructor = CriteriagroupContext;

CriteriagroupContext.prototype.OPENPAREN = function() {
    return this.getToken(AgiilQueryParser.OPENPAREN, 0);
};

CriteriagroupContext.prototype.logicalcriteriagroups = function() {
    return this.getTypedRuleContext(LogicalcriteriagroupsContext,0);
};

CriteriagroupContext.prototype.CLOSEPAREN = function() {
    return this.getToken(AgiilQueryParser.CLOSEPAREN, 0);
};

CriteriagroupContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitCriteriagroup(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.CriteriagroupContext = CriteriagroupContext;

AgiilQueryParser.prototype.criteriagroup = function() {

    var localctx = new CriteriagroupContext(this, this._ctx, this.state);
    this.enterRule(localctx, 6, AgiilQueryParser.RULE_criteriagroup);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 50;
        this.match(AgiilQueryParser.OPENPAREN);
        this.state = 51;
        this.logicalcriteriagroups();
        this.state = 52;
        this.match(AgiilQueryParser.CLOSEPAREN);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function CriterionContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_criterion;
    return this;
}

CriterionContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
CriterionContext.prototype.constructor = CriterionContext;

CriterionContext.prototype.element = function() {
    return this.getTypedRuleContext(ElementContext,0);
};

CriterionContext.prototype.elementtest = function() {
    return this.getTypedRuleContext(ElementtestContext,0);
};

CriterionContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitCriterion(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.CriterionContext = CriterionContext;

AgiilQueryParser.prototype.criterion = function() {

    var localctx = new CriterionContext(this, this._ctx, this.state);
    this.enterRule(localctx, 8, AgiilQueryParser.RULE_criterion);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 54;
        this.element();
        this.state = 55;
        this.elementtest();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ElementtestContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_elementtest;
    return this;
}

ElementtestContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ElementtestContext.prototype.constructor = ElementtestContext;

ElementtestContext.prototype.predicate = function() {
    return this.getTypedRuleContext(PredicateContext,0);
};

ElementtestContext.prototype.value = function() {
    return this.getTypedRuleContext(ValueContext,0);
};

ElementtestContext.prototype.functioninvocation = function() {
    return this.getTypedRuleContext(FunctioninvocationContext,0);
};

ElementtestContext.prototype.NOT = function() {
    return this.getToken(AgiilQueryParser.NOT, 0);
};

ElementtestContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitElementtest(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.ElementtestContext = ElementtestContext;

AgiilQueryParser.prototype.elementtest = function() {

    var localctx = new ElementtestContext(this, this._ctx, this.state);
    this.enterRule(localctx, 10, AgiilQueryParser.RULE_elementtest);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 64;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,6,this._ctx);
        switch(la_) {
        case 1:
            this.state = 57;
            this.predicate();
            this.state = 58;
            this.value();
            break;

        case 2:
            this.state = 61;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===AgiilQueryParser.NOT) {
                this.state = 60;
                this.match(AgiilQueryParser.NOT);
            }

            this.state = 63;
            this.functioninvocation();
            break;

        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function LogicalcombinationContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_logicalcombination;
    return this;
}

LogicalcombinationContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
LogicalcombinationContext.prototype.constructor = LogicalcombinationContext;

LogicalcombinationContext.prototype.AND = function() {
    return this.getToken(AgiilQueryParser.AND, 0);
};

LogicalcombinationContext.prototype.OR = function() {
    return this.getToken(AgiilQueryParser.OR, 0);
};

LogicalcombinationContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitLogicalcombination(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.LogicalcombinationContext = LogicalcombinationContext;

AgiilQueryParser.prototype.logicalcombination = function() {

    var localctx = new LogicalcombinationContext(this, this._ctx, this.state);
    this.enterRule(localctx, 12, AgiilQueryParser.RULE_logicalcombination);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 66;
        _la = this._input.LA(1);
        if(!(_la===AgiilQueryParser.AND || _la===AgiilQueryParser.OR)) {
        this._errHandler.recoverInline(this);
        }
        else {
        	this._errHandler.reportMatch(this);
            this.consume();
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ElementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_element;
    return this;
}

ElementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ElementContext.prototype.constructor = ElementContext;

ElementContext.prototype.NAME = function() {
    return this.getToken(AgiilQueryParser.NAME, 0);
};

ElementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitElement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.ElementContext = ElementContext;

AgiilQueryParser.prototype.element = function() {

    var localctx = new ElementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 14, AgiilQueryParser.RULE_element);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 68;
        this.match(AgiilQueryParser.NAME);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function PredicateContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_predicate;
    return this;
}

PredicateContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
PredicateContext.prototype.constructor = PredicateContext;

PredicateContext.prototype.predicatename = function() {
    return this.getTypedRuleContext(PredicatenameContext,0);
};

PredicateContext.prototype.NOT = function() {
    return this.getToken(AgiilQueryParser.NOT, 0);
};

PredicateContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitPredicate(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.PredicateContext = PredicateContext;

AgiilQueryParser.prototype.predicate = function() {

    var localctx = new PredicateContext(this, this._ctx, this.state);
    this.enterRule(localctx, 16, AgiilQueryParser.RULE_predicate);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 71;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.NOT) {
            this.state = 70;
            this.match(AgiilQueryParser.NOT);
        }

        this.state = 73;
        this.predicatename();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function PredicatenameContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_predicatename;
    return this;
}

PredicatenameContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
PredicatenameContext.prototype.constructor = PredicatenameContext;

PredicatenameContext.prototype.EQUALS = function() {
    return this.getToken(AgiilQueryParser.EQUALS, 0);
};

PredicatenameContext.prototype.NOTEQUALS = function() {
    return this.getToken(AgiilQueryParser.NOTEQUALS, 0);
};

PredicatenameContext.prototype.TILDE = function() {
    return this.getToken(AgiilQueryParser.TILDE, 0);
};

PredicatenameContext.prototype.NAME = function() {
    return this.getToken(AgiilQueryParser.NAME, 0);
};

PredicatenameContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitPredicatename(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.PredicatenameContext = PredicatenameContext;

AgiilQueryParser.prototype.predicatename = function() {

    var localctx = new PredicatenameContext(this, this._ctx, this.state);
    this.enterRule(localctx, 18, AgiilQueryParser.RULE_predicatename);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 75;
        _la = this._input.LA(1);
        if(!((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.EQUALS) | (1 << AgiilQueryParser.NOTEQUALS) | (1 << AgiilQueryParser.TILDE) | (1 << AgiilQueryParser.NAME))) !== 0))) {
        this._errHandler.recoverInline(this);
        }
        else {
        	this._errHandler.reportMatch(this);
            this.consume();
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ValueContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_value;
    return this;
}

ValueContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ValueContext.prototype.constructor = ValueContext;

ValueContext.prototype.constantvalue = function() {
    return this.getTypedRuleContext(ConstantvalueContext,0);
};

ValueContext.prototype.functioninvocation = function() {
    return this.getTypedRuleContext(FunctioninvocationContext,0);
};

ValueContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitValue(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.ValueContext = ValueContext;

AgiilQueryParser.prototype.value = function() {

    var localctx = new ValueContext(this, this._ctx, this.state);
    this.enterRule(localctx, 20, AgiilQueryParser.RULE_value);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 79;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,8,this._ctx);
        switch(la_) {
        case 1:
            this.state = 77;
            this.constantvalue();
            break;

        case 2:
            this.state = 78;
            this.functioninvocation();
            break;

        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ConstantvalueContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_constantvalue;
    return this;
}

ConstantvalueContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ConstantvalueContext.prototype.constructor = ConstantvalueContext;

ConstantvalueContext.prototype.NAME = function() {
    return this.getToken(AgiilQueryParser.NAME, 0);
};

ConstantvalueContext.prototype.NOT = function() {
    return this.getToken(AgiilQueryParser.NOT, 0);
};

ConstantvalueContext.prototype.AND = function() {
    return this.getToken(AgiilQueryParser.AND, 0);
};

ConstantvalueContext.prototype.OR = function() {
    return this.getToken(AgiilQueryParser.OR, 0);
};

ConstantvalueContext.prototype.QUOTEDVALUE = function() {
    return this.getToken(AgiilQueryParser.QUOTEDVALUE, 0);
};

ConstantvalueContext.prototype.WORD = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(AgiilQueryParser.WORD);
    } else {
        return this.getToken(AgiilQueryParser.WORD, i);
    }
};


ConstantvalueContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitConstantvalue(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.ConstantvalueContext = ConstantvalueContext;

AgiilQueryParser.prototype.constantvalue = function() {

    var localctx = new ConstantvalueContext(this, this._ctx, this.state);
    this.enterRule(localctx, 22, AgiilQueryParser.RULE_constantvalue);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 91;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.NAME:
            this.state = 81;
            this.match(AgiilQueryParser.NAME);
            break;
        case AgiilQueryParser.NOT:
            this.state = 82;
            this.match(AgiilQueryParser.NOT);
            break;
        case AgiilQueryParser.AND:
            this.state = 83;
            this.match(AgiilQueryParser.AND);
            break;
        case AgiilQueryParser.OR:
            this.state = 84;
            this.match(AgiilQueryParser.OR);
            break;
        case AgiilQueryParser.WORD:
            this.state = 86; 
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            do {
                this.state = 85;
                this.match(AgiilQueryParser.WORD);
                this.state = 88; 
                this._errHandler.sync(this);
                _la = this._input.LA(1);
            } while(_la===AgiilQueryParser.WORD);
            break;
        case AgiilQueryParser.QUOTEDVALUE:
            this.state = 90;
            this.match(AgiilQueryParser.QUOTEDVALUE);
            break;
        default:
            throw new antlr4.error.NoViableAltException(this);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function FunctioninvocationContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_functioninvocation;
    return this;
}

FunctioninvocationContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
FunctioninvocationContext.prototype.constructor = FunctioninvocationContext;

FunctioninvocationContext.prototype.NAME = function() {
    return this.getToken(AgiilQueryParser.NAME, 0);
};

FunctioninvocationContext.prototype.OPENPAREN = function() {
    return this.getToken(AgiilQueryParser.OPENPAREN, 0);
};

FunctioninvocationContext.prototype.functionparameters = function() {
    return this.getTypedRuleContext(FunctionparametersContext,0);
};

FunctioninvocationContext.prototype.CLOSEPAREN = function() {
    return this.getToken(AgiilQueryParser.CLOSEPAREN, 0);
};

FunctioninvocationContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitFunctioninvocation(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.FunctioninvocationContext = FunctioninvocationContext;

AgiilQueryParser.prototype.functioninvocation = function() {

    var localctx = new FunctioninvocationContext(this, this._ctx, this.state);
    this.enterRule(localctx, 24, AgiilQueryParser.RULE_functioninvocation);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 93;
        this.match(AgiilQueryParser.NAME);
        this.state = 94;
        this.match(AgiilQueryParser.OPENPAREN);
        this.state = 95;
        this.functionparameters();
        this.state = 96;
        this.match(AgiilQueryParser.CLOSEPAREN);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function FunctionparametersContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_functionparameters;
    return this;
}

FunctionparametersContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
FunctionparametersContext.prototype.constructor = FunctionparametersContext;

FunctionparametersContext.prototype.value = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(ValueContext);
    } else {
        return this.getTypedRuleContext(ValueContext,i);
    }
};

FunctionparametersContext.prototype.COMMA = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(AgiilQueryParser.COMMA);
    } else {
        return this.getToken(AgiilQueryParser.COMMA, i);
    }
};


FunctionparametersContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitFunctionparameters(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.FunctionparametersContext = FunctionparametersContext;

AgiilQueryParser.prototype.functionparameters = function() {

    var localctx = new FunctionparametersContext(this, this._ctx, this.state);
    this.enterRule(localctx, 26, AgiilQueryParser.RULE_functionparameters);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 106;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.NOT) | (1 << AgiilQueryParser.AND) | (1 << AgiilQueryParser.OR) | (1 << AgiilQueryParser.NAME) | (1 << AgiilQueryParser.WORD) | (1 << AgiilQueryParser.QUOTEDVALUE))) !== 0)) {
            this.state = 98;
            this.value();
            this.state = 103;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            while(_la===AgiilQueryParser.COMMA) {
                this.state = 99;
                this.match(AgiilQueryParser.COMMA);
                this.state = 100;
                this.value();
                this.state = 105;
                this._errHandler.sync(this);
                _la = this._input.LA(1);
            }
        }

    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};


exports.AgiilQueryParser = AgiilQueryParser;
