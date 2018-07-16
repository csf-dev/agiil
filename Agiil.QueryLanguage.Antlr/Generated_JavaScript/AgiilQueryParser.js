// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/Tools/../AgiilQuery.g4 by ANTLR 4.7.1
// jshint ignore: start
var antlr4 = require('antlr4/index');
var AgiilQueryVisitor = require('./AgiilQueryVisitor').AgiilQueryVisitor;

var grammarFileName = "AgiilQuery.g4";

var serializedATN = ["\u0003\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964",
    "\u0003\u0015\u008c\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004",
    "\t\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0004\u0007\t\u0007",
    "\u0004\b\t\b\u0004\t\t\t\u0004\n\t\n\u0004\u000b\t\u000b\u0004\f\t\f",
    "\u0004\r\t\r\u0004\u000e\t\u000e\u0004\u000f\t\u000f\u0004\u0010\t\u0010",
    "\u0004\u0011\t\u0011\u0004\u0012\t\u0012\u0003\u0002\u0005\u0002&\n",
    "\u0002\u0003\u0002\u0005\u0002)\n\u0002\u0003\u0002\u0005\u0002,\n\u0002",
    "\u0003\u0002\u0003\u0002\u0003\u0003\u0003\u0003\u0003\u0004\u0003\u0004",
    "\u0005\u00044\n\u0004\u0003\u0004\u0007\u00047\n\u0004\f\u0004\u000e",
    "\u0004:\u000b\u0004\u0003\u0005\u0003\u0005\u0005\u0005>\n\u0005\u0003",
    "\u0006\u0003\u0006\u0003\u0006\u0003\u0006\u0003\u0007\u0003\u0007\u0003",
    "\u0007\u0003\b\u0003\b\u0003\b\u0003\b\u0005\bK\n\b\u0003\b\u0005\b",
    "N\n\b\u0003\t\u0003\t\u0003\n\u0003\n\u0003\u000b\u0005\u000bU\n\u000b",
    "\u0003\u000b\u0003\u000b\u0003\f\u0003\f\u0003\r\u0003\r\u0005\r]\n",
    "\r\u0003\u000e\u0003\u000e\u0003\u000e\u0003\u000e\u0003\u000e\u0006",
    "\u000ed\n\u000e\r\u000e\u000e\u000ee\u0003\u000e\u0003\u000e\u0003\u000e",
    "\u0005\u000ek\n\u000e\u0003\u000f\u0003\u000f\u0003\u000f\u0003\u000f",
    "\u0003\u000f\u0003\u0010\u0003\u0010\u0003\u0010\u0007\u0010u\n\u0010",
    "\f\u0010\u000e\u0010x\u000b\u0010\u0005\u0010z\n\u0010\u0003\u0011\u0003",
    "\u0011\u0003\u0011\u0003\u0011\u0007\u0011\u0080\n\u0011\f\u0011\u000e",
    "\u0011\u0083\u000b\u0011\u0003\u0012\u0003\u0012\u0005\u0012\u0087\n",
    "\u0012\u0003\u0012\u0005\u0012\u008a\n\u0012\u0003\u0012\u0002\u0002",
    "\u0013\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a",
    "\u001c\u001e \"\u0002\u0005\u0003\u0002\r\u000e\u0004\u0002\u0006\b",
    "\u0012\u0012\u0003\u0002\u0010\u0011\u0002\u0091\u0002%\u0003\u0002",
    "\u0002\u0002\u0004/\u0003\u0002\u0002\u0002\u00061\u0003\u0002\u0002",
    "\u0002\b=\u0003\u0002\u0002\u0002\n?\u0003\u0002\u0002\u0002\fC\u0003",
    "\u0002\u0002\u0002\u000eM\u0003\u0002\u0002\u0002\u0010O\u0003\u0002",
    "\u0002\u0002\u0012Q\u0003\u0002\u0002\u0002\u0014T\u0003\u0002\u0002",
    "\u0002\u0016X\u0003\u0002\u0002\u0002\u0018\\\u0003\u0002\u0002\u0002",
    "\u001aj\u0003\u0002\u0002\u0002\u001cl\u0003\u0002\u0002\u0002\u001e",
    "y\u0003\u0002\u0002\u0002 {\u0003\u0002\u0002\u0002\"\u0086\u0003\u0002",
    "\u0002\u0002$&\u0007\u0003\u0002\u0002%$\u0003\u0002\u0002\u0002%&\u0003",
    "\u0002\u0002\u0002&(\u0003\u0002\u0002\u0002\')\u0005\u0004\u0003\u0002",
    "(\'\u0003\u0002\u0002\u0002()\u0003\u0002\u0002\u0002)+\u0003\u0002",
    "\u0002\u0002*,\u0005 \u0011\u0002+*\u0003\u0002\u0002\u0002+,\u0003",
    "\u0002\u0002\u0002,-\u0003\u0002\u0002\u0002-.\u0007\u0002\u0002\u0003",
    ".\u0003\u0003\u0002\u0002\u0002/0\u0005\u0006\u0004\u00020\u0005\u0003",
    "\u0002\u0002\u000218\u0005\b\u0005\u000224\u0005\u0010\t\u000232\u0003",
    "\u0002\u0002\u000234\u0003\u0002\u0002\u000245\u0003\u0002\u0002\u0002",
    "57\u0005\b\u0005\u000263\u0003\u0002\u0002\u00027:\u0003\u0002\u0002",
    "\u000286\u0003\u0002\u0002\u000289\u0003\u0002\u0002\u00029\u0007\u0003",
    "\u0002\u0002\u0002:8\u0003\u0002\u0002\u0002;>\u0005\f\u0007\u0002<",
    ">\u0005\n\u0006\u0002=;\u0003\u0002\u0002\u0002=<\u0003\u0002\u0002",
    "\u0002>\t\u0003\u0002\u0002\u0002?@\u0007\u0004\u0002\u0002@A\u0005",
    "\u0006\u0004\u0002AB\u0007\u0005\u0002\u0002B\u000b\u0003\u0002\u0002",
    "\u0002CD\u0005\u0012\n\u0002DE\u0005\u000e\b\u0002E\r\u0003\u0002\u0002",
    "\u0002FG\u0005\u0014\u000b\u0002GH\u0005\u0018\r\u0002HN\u0003\u0002",
    "\u0002\u0002IK\u0007\f\u0002\u0002JI\u0003\u0002\u0002\u0002JK\u0003",
    "\u0002\u0002\u0002KL\u0003\u0002\u0002\u0002LN\u0005\u001c\u000f\u0002",
    "MF\u0003\u0002\u0002\u0002MJ\u0003\u0002\u0002\u0002N\u000f\u0003\u0002",
    "\u0002\u0002OP\t\u0002\u0002\u0002P\u0011\u0003\u0002\u0002\u0002QR",
    "\u0007\u0012\u0002\u0002R\u0013\u0003\u0002\u0002\u0002SU\u0007\f\u0002",
    "\u0002TS\u0003\u0002\u0002\u0002TU\u0003\u0002\u0002\u0002UV\u0003\u0002",
    "\u0002\u0002VW\u0005\u0016\f\u0002W\u0015\u0003\u0002\u0002\u0002XY",
    "\t\u0003\u0002\u0002Y\u0017\u0003\u0002\u0002\u0002Z]\u0005\u001a\u000e",
    "\u0002[]\u0005\u001c\u000f\u0002\\Z\u0003\u0002\u0002\u0002\\[\u0003",
    "\u0002\u0002\u0002]\u0019\u0003\u0002\u0002\u0002^k\u0007\u0012\u0002",
    "\u0002_k\u0007\f\u0002\u0002`k\u0007\r\u0002\u0002ak\u0007\u000e\u0002",
    "\u0002bd\u0007\u0013\u0002\u0002cb\u0003\u0002\u0002\u0002de\u0003\u0002",
    "\u0002\u0002ec\u0003\u0002\u0002\u0002ef\u0003\u0002\u0002\u0002fk\u0003",
    "\u0002\u0002\u0002gk\u0007\u0010\u0002\u0002hk\u0007\u0011\u0002\u0002",
    "ik\u0007\u0014\u0002\u0002j^\u0003\u0002\u0002\u0002j_\u0003\u0002\u0002",
    "\u0002j`\u0003\u0002\u0002\u0002ja\u0003\u0002\u0002\u0002jc\u0003\u0002",
    "\u0002\u0002jg\u0003\u0002\u0002\u0002jh\u0003\u0002\u0002\u0002ji\u0003",
    "\u0002\u0002\u0002k\u001b\u0003\u0002\u0002\u0002lm\u0007\u0012\u0002",
    "\u0002mn\u0007\u0004\u0002\u0002no\u0005\u001e\u0010\u0002op\u0007\u0005",
    "\u0002\u0002p\u001d\u0003\u0002\u0002\u0002qv\u0005\u0018\r\u0002rs",
    "\u0007\t\u0002\u0002su\u0005\u0018\r\u0002tr\u0003\u0002\u0002\u0002",
    "ux\u0003\u0002\u0002\u0002vt\u0003\u0002\u0002\u0002vw\u0003\u0002\u0002",
    "\u0002wz\u0003\u0002\u0002\u0002xv\u0003\u0002\u0002\u0002yq\u0003\u0002",
    "\u0002\u0002yz\u0003\u0002\u0002\u0002z\u001f\u0003\u0002\u0002\u0002",
    "{|\u0007\u000f\u0002\u0002|\u0081\u0005\"\u0012\u0002}~\u0007\t\u0002",
    "\u0002~\u0080\u0005\"\u0012\u0002\u007f}\u0003\u0002\u0002\u0002\u0080",
    "\u0083\u0003\u0002\u0002\u0002\u0081\u007f\u0003\u0002\u0002\u0002\u0081",
    "\u0082\u0003\u0002\u0002\u0002\u0082!\u0003\u0002\u0002\u0002\u0083",
    "\u0081\u0003\u0002\u0002\u0002\u0084\u0087\u0007\u0012\u0002\u0002\u0085",
    "\u0087\u0005\u001c\u000f\u0002\u0086\u0084\u0003\u0002\u0002\u0002\u0086",
    "\u0085\u0003\u0002\u0002\u0002\u0087\u0089\u0003\u0002\u0002\u0002\u0088",
    "\u008a\t\u0004\u0002\u0002\u0089\u0088\u0003\u0002\u0002\u0002\u0089",
    "\u008a\u0003\u0002\u0002\u0002\u008a#\u0003\u0002\u0002\u0002\u0013",
    "%(+38=JMT\\ejvy\u0081\u0086\u0089"].join("");


var atn = new antlr4.atn.ATNDeserializer().deserialize(serializedATN);

var decisionsToDFA = atn.decisionToState.map( function(ds, index) { return new antlr4.dfa.DFA(ds, index); });

var sharedContextCache = new antlr4.PredictionContextCache();

var literalNames = [ null, "'\uFEFF'", "'('", "')'", "'='", "'!='", "'~'", 
                     "','", "'\"'" ];

var symbolicNames = [ null, "BOM", "OPENPAREN", "CLOSEPAREN", "EQUALS", 
                      "NOTEQUALS", "TILDE", "COMMA", "DOUBLEQUOTE", "WHITESPACE", 
                      "NOT", "AND", "OR", "ORDERBY", "DESCENDING", "ASCENDING", 
                      "NAME", "WORD", "QUOTEDVALUE", "ANY" ];

var ruleNames =  [ "search", "criteria", "logicalcriteriagroups", "criterionorgroup", 
                   "criteriagroup", "criterion", "elementtest", "logicaloperator", 
                   "element", "predicate", "predicatename", "value", "constantvalue", 
                   "functioninvocation", "functionparameters", "orders", 
                   "orderelement" ];

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
AgiilQueryParser.DOUBLEQUOTE = 8;
AgiilQueryParser.WHITESPACE = 9;
AgiilQueryParser.NOT = 10;
AgiilQueryParser.AND = 11;
AgiilQueryParser.OR = 12;
AgiilQueryParser.ORDERBY = 13;
AgiilQueryParser.DESCENDING = 14;
AgiilQueryParser.ASCENDING = 15;
AgiilQueryParser.NAME = 16;
AgiilQueryParser.WORD = 17;
AgiilQueryParser.QUOTEDVALUE = 18;
AgiilQueryParser.ANY = 19;

AgiilQueryParser.RULE_search = 0;
AgiilQueryParser.RULE_criteria = 1;
AgiilQueryParser.RULE_logicalcriteriagroups = 2;
AgiilQueryParser.RULE_criterionorgroup = 3;
AgiilQueryParser.RULE_criteriagroup = 4;
AgiilQueryParser.RULE_criterion = 5;
AgiilQueryParser.RULE_elementtest = 6;
AgiilQueryParser.RULE_logicaloperator = 7;
AgiilQueryParser.RULE_element = 8;
AgiilQueryParser.RULE_predicate = 9;
AgiilQueryParser.RULE_predicatename = 10;
AgiilQueryParser.RULE_value = 11;
AgiilQueryParser.RULE_constantvalue = 12;
AgiilQueryParser.RULE_functioninvocation = 13;
AgiilQueryParser.RULE_functionparameters = 14;
AgiilQueryParser.RULE_orders = 15;
AgiilQueryParser.RULE_orderelement = 16;

function SearchContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_search;
    return this;
}

SearchContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
SearchContext.prototype.constructor = SearchContext;

SearchContext.prototype.EOF = function() {
    return this.getToken(AgiilQueryParser.EOF, 0);
};

SearchContext.prototype.BOM = function() {
    return this.getToken(AgiilQueryParser.BOM, 0);
};

SearchContext.prototype.criteria = function() {
    return this.getTypedRuleContext(CriteriaContext,0);
};

SearchContext.prototype.orders = function() {
    return this.getTypedRuleContext(OrdersContext,0);
};

SearchContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitSearch(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.SearchContext = SearchContext;

AgiilQueryParser.prototype.search = function() {

    var localctx = new SearchContext(this, this._ctx, this.state);
    this.enterRule(localctx, 0, AgiilQueryParser.RULE_search);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 35;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.BOM) {
            this.state = 34;
            this.match(AgiilQueryParser.BOM);
        }

        this.state = 38;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.OPENPAREN || _la===AgiilQueryParser.NAME) {
            this.state = 37;
            this.criteria();
        }

        this.state = 41;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.ORDERBY) {
            this.state = 40;
            this.orders();
        }

        this.state = 43;
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
    this.enterRule(localctx, 2, AgiilQueryParser.RULE_criteria);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 45;
        this.logicalcriteriagroups();
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

LogicalcriteriagroupsContext.prototype.logicaloperator = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(LogicaloperatorContext);
    } else {
        return this.getTypedRuleContext(LogicaloperatorContext,i);
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
    this.enterRule(localctx, 4, AgiilQueryParser.RULE_logicalcriteriagroups);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 47;
        this.criterionorgroup();
        this.state = 54;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.OPENPAREN) | (1 << AgiilQueryParser.AND) | (1 << AgiilQueryParser.OR) | (1 << AgiilQueryParser.NAME))) !== 0)) {
            this.state = 49;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===AgiilQueryParser.AND || _la===AgiilQueryParser.OR) {
                this.state = 48;
                this.logicaloperator();
            }

            this.state = 51;
            this.criterionorgroup();
            this.state = 56;
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
    this.enterRule(localctx, 6, AgiilQueryParser.RULE_criterionorgroup);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 59;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.NAME:
            this.state = 57;
            this.criterion();
            break;
        case AgiilQueryParser.OPENPAREN:
            this.state = 58;
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
    this.enterRule(localctx, 8, AgiilQueryParser.RULE_criteriagroup);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 61;
        this.match(AgiilQueryParser.OPENPAREN);
        this.state = 62;
        this.logicalcriteriagroups();
        this.state = 63;
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
    this.enterRule(localctx, 10, AgiilQueryParser.RULE_criterion);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 65;
        this.element();
        this.state = 66;
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
    this.enterRule(localctx, 12, AgiilQueryParser.RULE_elementtest);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 75;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,7,this._ctx);
        switch(la_) {
        case 1:
            this.state = 68;
            this.predicate();
            this.state = 69;
            this.value();
            break;

        case 2:
            this.state = 72;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===AgiilQueryParser.NOT) {
                this.state = 71;
                this.match(AgiilQueryParser.NOT);
            }

            this.state = 74;
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

function LogicaloperatorContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_logicaloperator;
    return this;
}

LogicaloperatorContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
LogicaloperatorContext.prototype.constructor = LogicaloperatorContext;

LogicaloperatorContext.prototype.AND = function() {
    return this.getToken(AgiilQueryParser.AND, 0);
};

LogicaloperatorContext.prototype.OR = function() {
    return this.getToken(AgiilQueryParser.OR, 0);
};

LogicaloperatorContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitLogicaloperator(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.LogicaloperatorContext = LogicaloperatorContext;

AgiilQueryParser.prototype.logicaloperator = function() {

    var localctx = new LogicaloperatorContext(this, this._ctx, this.state);
    this.enterRule(localctx, 14, AgiilQueryParser.RULE_logicaloperator);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 77;
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
    this.enterRule(localctx, 16, AgiilQueryParser.RULE_element);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 79;
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
    this.enterRule(localctx, 18, AgiilQueryParser.RULE_predicate);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 82;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.NOT) {
            this.state = 81;
            this.match(AgiilQueryParser.NOT);
        }

        this.state = 84;
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
    this.enterRule(localctx, 20, AgiilQueryParser.RULE_predicatename);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 86;
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
    this.enterRule(localctx, 22, AgiilQueryParser.RULE_value);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 90;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,9,this._ctx);
        switch(la_) {
        case 1:
            this.state = 88;
            this.constantvalue();
            break;

        case 2:
            this.state = 89;
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

ConstantvalueContext.prototype.DESCENDING = function() {
    return this.getToken(AgiilQueryParser.DESCENDING, 0);
};

ConstantvalueContext.prototype.ASCENDING = function() {
    return this.getToken(AgiilQueryParser.ASCENDING, 0);
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
    this.enterRule(localctx, 24, AgiilQueryParser.RULE_constantvalue);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 104;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.NAME:
            this.state = 92;
            this.match(AgiilQueryParser.NAME);
            break;
        case AgiilQueryParser.NOT:
            this.state = 93;
            this.match(AgiilQueryParser.NOT);
            break;
        case AgiilQueryParser.AND:
            this.state = 94;
            this.match(AgiilQueryParser.AND);
            break;
        case AgiilQueryParser.OR:
            this.state = 95;
            this.match(AgiilQueryParser.OR);
            break;
        case AgiilQueryParser.WORD:
            this.state = 97; 
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            do {
                this.state = 96;
                this.match(AgiilQueryParser.WORD);
                this.state = 99; 
                this._errHandler.sync(this);
                _la = this._input.LA(1);
            } while(_la===AgiilQueryParser.WORD);
            break;
        case AgiilQueryParser.DESCENDING:
            this.state = 101;
            this.match(AgiilQueryParser.DESCENDING);
            break;
        case AgiilQueryParser.ASCENDING:
            this.state = 102;
            this.match(AgiilQueryParser.ASCENDING);
            break;
        case AgiilQueryParser.QUOTEDVALUE:
            this.state = 103;
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
    this.enterRule(localctx, 26, AgiilQueryParser.RULE_functioninvocation);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 106;
        this.match(AgiilQueryParser.NAME);
        this.state = 107;
        this.match(AgiilQueryParser.OPENPAREN);
        this.state = 108;
        this.functionparameters();
        this.state = 109;
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
    this.enterRule(localctx, 28, AgiilQueryParser.RULE_functionparameters);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 119;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.NOT) | (1 << AgiilQueryParser.AND) | (1 << AgiilQueryParser.OR) | (1 << AgiilQueryParser.DESCENDING) | (1 << AgiilQueryParser.ASCENDING) | (1 << AgiilQueryParser.NAME) | (1 << AgiilQueryParser.WORD) | (1 << AgiilQueryParser.QUOTEDVALUE))) !== 0)) {
            this.state = 111;
            this.value();
            this.state = 116;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            while(_la===AgiilQueryParser.COMMA) {
                this.state = 112;
                this.match(AgiilQueryParser.COMMA);
                this.state = 113;
                this.value();
                this.state = 118;
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

function OrdersContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_orders;
    return this;
}

OrdersContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
OrdersContext.prototype.constructor = OrdersContext;

OrdersContext.prototype.ORDERBY = function() {
    return this.getToken(AgiilQueryParser.ORDERBY, 0);
};

OrdersContext.prototype.orderelement = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(OrderelementContext);
    } else {
        return this.getTypedRuleContext(OrderelementContext,i);
    }
};

OrdersContext.prototype.COMMA = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(AgiilQueryParser.COMMA);
    } else {
        return this.getToken(AgiilQueryParser.COMMA, i);
    }
};


OrdersContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitOrders(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.OrdersContext = OrdersContext;

AgiilQueryParser.prototype.orders = function() {

    var localctx = new OrdersContext(this, this._ctx, this.state);
    this.enterRule(localctx, 30, AgiilQueryParser.RULE_orders);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 121;
        this.match(AgiilQueryParser.ORDERBY);
        this.state = 122;
        this.orderelement();
        this.state = 127;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===AgiilQueryParser.COMMA) {
            this.state = 123;
            this.match(AgiilQueryParser.COMMA);
            this.state = 124;
            this.orderelement();
            this.state = 129;
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

function OrderelementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_orderelement;
    return this;
}

OrderelementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
OrderelementContext.prototype.constructor = OrderelementContext;

OrderelementContext.prototype.NAME = function() {
    return this.getToken(AgiilQueryParser.NAME, 0);
};

OrderelementContext.prototype.functioninvocation = function() {
    return this.getTypedRuleContext(FunctioninvocationContext,0);
};

OrderelementContext.prototype.ASCENDING = function() {
    return this.getToken(AgiilQueryParser.ASCENDING, 0);
};

OrderelementContext.prototype.DESCENDING = function() {
    return this.getToken(AgiilQueryParser.DESCENDING, 0);
};

OrderelementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitOrderelement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.OrderelementContext = OrderelementContext;

AgiilQueryParser.prototype.orderelement = function() {

    var localctx = new OrderelementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 32, AgiilQueryParser.RULE_orderelement);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 132;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,15,this._ctx);
        switch(la_) {
        case 1:
            this.state = 130;
            this.match(AgiilQueryParser.NAME);
            break;

        case 2:
            this.state = 131;
            this.functioninvocation();
            break;

        }
        this.state = 135;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.DESCENDING || _la===AgiilQueryParser.ASCENDING) {
            this.state = 134;
            _la = this._input.LA(1);
            if(!(_la===AgiilQueryParser.DESCENDING || _la===AgiilQueryParser.ASCENDING)) {
            this._errHandler.recoverInline(this);
            }
            else {
            	this._errHandler.reportMatch(this);
                this.consume();
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
