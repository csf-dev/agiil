// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/AgiilQuery.g4 by ANTLR 4.7.1
// jshint ignore: start
var antlr4 = require('antlr4/index');
var AgiilQueryVisitor = require('./AgiilQueryVisitor').AgiilQueryVisitor;

var grammarFileName = "AgiilQuery.g4";

var serializedATN = ["\u0003\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964",
    "\u0003\u0019\u0095\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004",
    "\t\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0004\u0007\t\u0007",
    "\u0004\b\t\b\u0004\t\t\t\u0004\n\t\n\u0004\u000b\t\u000b\u0004\f\t\f",
    "\u0004\r\t\r\u0004\u000e\t\u000e\u0004\u000f\t\u000f\u0004\u0010\t\u0010",
    "\u0004\u0011\t\u0011\u0004\u0012\t\u0012\u0004\u0013\t\u0013\u0003\u0002",
    "\u0005\u0002(\n\u0002\u0003\u0002\u0005\u0002+\n\u0002\u0003\u0002\u0005",
    "\u0002.\n\u0002\u0003\u0002\u0003\u0002\u0003\u0003\u0003\u0003\u0003",
    "\u0004\u0003\u0004\u0005\u00046\n\u0004\u0003\u0004\u0007\u00049\n\u0004",
    "\f\u0004\u000e\u0004<\u000b\u0004\u0003\u0005\u0003\u0005\u0005\u0005",
    "@\n\u0005\u0003\u0006\u0003\u0006\u0003\u0006\u0003\u0006\u0003\u0007",
    "\u0003\u0007\u0003\u0007\u0003\b\u0003\b\u0003\b\u0003\b\u0005\bM\n",
    "\b\u0003\b\u0005\bP\n\b\u0003\t\u0003\t\u0003\n\u0003\n\u0003\u000b",
    "\u0005\u000bW\n\u000b\u0003\u000b\u0003\u000b\u0003\f\u0003\f\u0003",
    "\f\u0003\f\u0003\f\u0005\f`\n\f\u0003\r\u0003\r\u0003\u000e\u0003\u000e",
    "\u0005\u000ef\n\u000e\u0003\u000f\u0003\u000f\u0003\u000f\u0003\u000f",
    "\u0003\u000f\u0006\u000fm\n\u000f\r\u000f\u000e\u000fn\u0003\u000f\u0003",
    "\u000f\u0003\u000f\u0005\u000ft\n\u000f\u0003\u0010\u0003\u0010\u0003",
    "\u0010\u0003\u0010\u0003\u0010\u0003\u0011\u0003\u0011\u0003\u0011\u0007",
    "\u0011~\n\u0011\f\u0011\u000e\u0011\u0081\u000b\u0011\u0005\u0011\u0083",
    "\n\u0011\u0003\u0012\u0003\u0012\u0003\u0012\u0003\u0012\u0007\u0012",
    "\u0089\n\u0012\f\u0012\u000e\u0012\u008c\u000b\u0012\u0003\u0013\u0003",
    "\u0013\u0005\u0013\u0090\n\u0013\u0003\u0013\u0005\u0013\u0093\n\u0013",
    "\u0003\u0013\u0002\u0002\u0014\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012",
    "\u0014\u0016\u0018\u001a\u001c\u001e \"$\u0002\u0005\u0003\u0002\u0011",
    "\u0012\u0003\u0002\u000b\u000e\u0003\u0002\u0014\u0015\u0002\u009d\u0002",
    "\'\u0003\u0002\u0002\u0002\u00041\u0003\u0002\u0002\u0002\u00063\u0003",
    "\u0002\u0002\u0002\b?\u0003\u0002\u0002\u0002\nA\u0003\u0002\u0002\u0002",
    "\fE\u0003\u0002\u0002\u0002\u000eO\u0003\u0002\u0002\u0002\u0010Q\u0003",
    "\u0002\u0002\u0002\u0012S\u0003\u0002\u0002\u0002\u0014V\u0003\u0002",
    "\u0002\u0002\u0016_\u0003\u0002\u0002\u0002\u0018a\u0003\u0002\u0002",
    "\u0002\u001ae\u0003\u0002\u0002\u0002\u001cs\u0003\u0002\u0002\u0002",
    "\u001eu\u0003\u0002\u0002\u0002 \u0082\u0003\u0002\u0002\u0002\"\u0084",
    "\u0003\u0002\u0002\u0002$\u008f\u0003\u0002\u0002\u0002&(\u0007\u0003",
    "\u0002\u0002\'&\u0003\u0002\u0002\u0002\'(\u0003\u0002\u0002\u0002(",
    "*\u0003\u0002\u0002\u0002)+\u0005\u0004\u0003\u0002*)\u0003\u0002\u0002",
    "\u0002*+\u0003\u0002\u0002\u0002+-\u0003\u0002\u0002\u0002,.\u0005\"",
    "\u0012\u0002-,\u0003\u0002\u0002\u0002-.\u0003\u0002\u0002\u0002./\u0003",
    "\u0002\u0002\u0002/0\u0007\u0002\u0002\u00030\u0003\u0003\u0002\u0002",
    "\u000212\u0005\u0006\u0004\u00022\u0005\u0003\u0002\u0002\u00023:\u0005",
    "\b\u0005\u000246\u0005\u0010\t\u000254\u0003\u0002\u0002\u000256\u0003",
    "\u0002\u0002\u000267\u0003\u0002\u0002\u000279\u0005\b\u0005\u00028",
    "5\u0003\u0002\u0002\u00029<\u0003\u0002\u0002\u0002:8\u0003\u0002\u0002",
    "\u0002:;\u0003\u0002\u0002\u0002;\u0007\u0003\u0002\u0002\u0002<:\u0003",
    "\u0002\u0002\u0002=@\u0005\f\u0007\u0002>@\u0005\n\u0006\u0002?=\u0003",
    "\u0002\u0002\u0002?>\u0003\u0002\u0002\u0002@\t\u0003\u0002\u0002\u0002",
    "AB\u0007\u0004\u0002\u0002BC\u0005\u0006\u0004\u0002CD\u0007\u0005\u0002",
    "\u0002D\u000b\u0003\u0002\u0002\u0002EF\u0005\u0012\n\u0002FG\u0005",
    "\u000e\b\u0002G\r\u0003\u0002\u0002\u0002HI\u0005\u0014\u000b\u0002",
    "IJ\u0005\u001a\u000e\u0002JP\u0003\u0002\u0002\u0002KM\u0007\u0010\u0002",
    "\u0002LK\u0003\u0002\u0002\u0002LM\u0003\u0002\u0002\u0002MN\u0003\u0002",
    "\u0002\u0002NP\u0005\u001e\u0010\u0002OH\u0003\u0002\u0002\u0002OL\u0003",
    "\u0002\u0002\u0002P\u000f\u0003\u0002\u0002\u0002QR\t\u0002\u0002\u0002",
    "R\u0011\u0003\u0002\u0002\u0002ST\u0007\u0016\u0002\u0002T\u0013\u0003",
    "\u0002\u0002\u0002UW\u0007\u0010\u0002\u0002VU\u0003\u0002\u0002\u0002",
    "VW\u0003\u0002\u0002\u0002WX\u0003\u0002\u0002\u0002XY\u0005\u0016\f",
    "\u0002Y\u0015\u0003\u0002\u0002\u0002Z`\u0007\u0006\u0002\u0002[`\u0007",
    "\u0007\u0002\u0002\\`\u0007\b\u0002\u0002]`\u0007\u0016\u0002\u0002",
    "^`\u0005\u0018\r\u0002_Z\u0003\u0002\u0002\u0002_[\u0003\u0002\u0002",
    "\u0002_\\\u0003\u0002\u0002\u0002_]\u0003\u0002\u0002\u0002_^\u0003",
    "\u0002\u0002\u0002`\u0017\u0003\u0002\u0002\u0002ab\t\u0003\u0002\u0002",
    "b\u0019\u0003\u0002\u0002\u0002cf\u0005\u001c\u000f\u0002df\u0005\u001e",
    "\u0010\u0002ec\u0003\u0002\u0002\u0002ed\u0003\u0002\u0002\u0002f\u001b",
    "\u0003\u0002\u0002\u0002gt\u0007\u0016\u0002\u0002ht\u0007\u0010\u0002",
    "\u0002it\u0007\u0011\u0002\u0002jt\u0007\u0012\u0002\u0002km\u0007\u0017",
    "\u0002\u0002lk\u0003\u0002\u0002\u0002mn\u0003\u0002\u0002\u0002nl\u0003",
    "\u0002\u0002\u0002no\u0003\u0002\u0002\u0002ot\u0003\u0002\u0002\u0002",
    "pt\u0007\u0014\u0002\u0002qt\u0007\u0015\u0002\u0002rt\u0007\u0018\u0002",
    "\u0002sg\u0003\u0002\u0002\u0002sh\u0003\u0002\u0002\u0002si\u0003\u0002",
    "\u0002\u0002sj\u0003\u0002\u0002\u0002sl\u0003\u0002\u0002\u0002sp\u0003",
    "\u0002\u0002\u0002sq\u0003\u0002\u0002\u0002sr\u0003\u0002\u0002\u0002",
    "t\u001d\u0003\u0002\u0002\u0002uv\u0007\u0016\u0002\u0002vw\u0007\u0004",
    "\u0002\u0002wx\u0005 \u0011\u0002xy\u0007\u0005\u0002\u0002y\u001f\u0003",
    "\u0002\u0002\u0002z\u007f\u0005\u001a\u000e\u0002{|\u0007\t\u0002\u0002",
    "|~\u0005\u001a\u000e\u0002}{\u0003\u0002\u0002\u0002~\u0081\u0003\u0002",
    "\u0002\u0002\u007f}\u0003\u0002\u0002\u0002\u007f\u0080\u0003\u0002",
    "\u0002\u0002\u0080\u0083\u0003\u0002\u0002\u0002\u0081\u007f\u0003\u0002",
    "\u0002\u0002\u0082z\u0003\u0002\u0002\u0002\u0082\u0083\u0003\u0002",
    "\u0002\u0002\u0083!\u0003\u0002\u0002\u0002\u0084\u0085\u0007\u0013",
    "\u0002\u0002\u0085\u008a\u0005$\u0013\u0002\u0086\u0087\u0007\t\u0002",
    "\u0002\u0087\u0089\u0005$\u0013\u0002\u0088\u0086\u0003\u0002\u0002",
    "\u0002\u0089\u008c\u0003\u0002\u0002\u0002\u008a\u0088\u0003\u0002\u0002",
    "\u0002\u008a\u008b\u0003\u0002\u0002\u0002\u008b#\u0003\u0002\u0002",
    "\u0002\u008c\u008a\u0003\u0002\u0002\u0002\u008d\u0090\u0007\u0016\u0002",
    "\u0002\u008e\u0090\u0005\u001e\u0010\u0002\u008f\u008d\u0003\u0002\u0002",
    "\u0002\u008f\u008e\u0003\u0002\u0002\u0002\u0090\u0092\u0003\u0002\u0002",
    "\u0002\u0091\u0093\t\u0004\u0002\u0002\u0092\u0091\u0003\u0002\u0002",
    "\u0002\u0092\u0093\u0003\u0002\u0002\u0002\u0093%\u0003\u0002\u0002",
    "\u0002\u0014\'*-5:?LOV_ens\u007f\u0082\u008a\u008f\u0092"].join("");


var atn = new antlr4.atn.ATNDeserializer().deserialize(serializedATN);

var decisionsToDFA = atn.decisionToState.map( function(ds, index) { return new antlr4.dfa.DFA(ds, index); });

var sharedContextCache = new antlr4.PredictionContextCache();

var literalNames = [ null, "'\uFEFF'", "'('", "')'", "'='", "'!='", "'~'", 
                     "','", "'\"'", "'>'", "'<'", "'>='", "'<='" ];

var symbolicNames = [ null, "BOM", "OPENPAREN", "CLOSEPAREN", "EQUALS", 
                      "NOTEQUALS", "TILDE", "COMMA", "DOUBLEQUOTE", "GREATERTHAN", 
                      "LESSTHAN", "GREATERTHANOREQUAL", "LESSTHANOREQUAL", 
                      "WHITESPACE", "NOT", "AND", "OR", "ORDERBY", "DESCENDING", 
                      "ASCENDING", "NAME", "WORD", "QUOTEDVALUE", "ANY" ];

var ruleNames =  [ "search", "criteria", "logicalcriteriagroups", "criterionorgroup", 
                   "criteriagroup", "criterion", "elementtest", "logicaloperator", 
                   "element", "predicate", "predicatename", "comparison", 
                   "value", "constantvalue", "functioninvocation", "functionparameters", 
                   "orders", "orderelement" ];

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
AgiilQueryParser.GREATERTHAN = 9;
AgiilQueryParser.LESSTHAN = 10;
AgiilQueryParser.GREATERTHANOREQUAL = 11;
AgiilQueryParser.LESSTHANOREQUAL = 12;
AgiilQueryParser.WHITESPACE = 13;
AgiilQueryParser.NOT = 14;
AgiilQueryParser.AND = 15;
AgiilQueryParser.OR = 16;
AgiilQueryParser.ORDERBY = 17;
AgiilQueryParser.DESCENDING = 18;
AgiilQueryParser.ASCENDING = 19;
AgiilQueryParser.NAME = 20;
AgiilQueryParser.WORD = 21;
AgiilQueryParser.QUOTEDVALUE = 22;
AgiilQueryParser.ANY = 23;

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
AgiilQueryParser.RULE_comparison = 11;
AgiilQueryParser.RULE_value = 12;
AgiilQueryParser.RULE_constantvalue = 13;
AgiilQueryParser.RULE_functioninvocation = 14;
AgiilQueryParser.RULE_functionparameters = 15;
AgiilQueryParser.RULE_orders = 16;
AgiilQueryParser.RULE_orderelement = 17;

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
        this.state = 37;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.BOM) {
            this.state = 36;
            this.match(AgiilQueryParser.BOM);
        }

        this.state = 40;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.OPENPAREN || _la===AgiilQueryParser.NAME) {
            this.state = 39;
            this.criteria();
        }

        this.state = 43;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.ORDERBY) {
            this.state = 42;
            this.orders();
        }

        this.state = 45;
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
        this.state = 47;
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
        this.state = 49;
        this.criterionorgroup();
        this.state = 56;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.OPENPAREN) | (1 << AgiilQueryParser.AND) | (1 << AgiilQueryParser.OR) | (1 << AgiilQueryParser.NAME))) !== 0)) {
            this.state = 51;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===AgiilQueryParser.AND || _la===AgiilQueryParser.OR) {
                this.state = 50;
                this.logicaloperator();
            }

            this.state = 53;
            this.criterionorgroup();
            this.state = 58;
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
        this.state = 61;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.NAME:
            this.state = 59;
            this.criterion();
            break;
        case AgiilQueryParser.OPENPAREN:
            this.state = 60;
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
        this.state = 63;
        this.match(AgiilQueryParser.OPENPAREN);
        this.state = 64;
        this.logicalcriteriagroups();
        this.state = 65;
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
        this.state = 67;
        this.element();
        this.state = 68;
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
        this.state = 77;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,7,this._ctx);
        switch(la_) {
        case 1:
            this.state = 70;
            this.predicate();
            this.state = 71;
            this.value();
            break;

        case 2:
            this.state = 74;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===AgiilQueryParser.NOT) {
                this.state = 73;
                this.match(AgiilQueryParser.NOT);
            }

            this.state = 76;
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
        this.state = 79;
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
        this.state = 81;
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
        this.state = 84;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.NOT) {
            this.state = 83;
            this.match(AgiilQueryParser.NOT);
        }

        this.state = 86;
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

PredicatenameContext.prototype.comparison = function() {
    return this.getTypedRuleContext(ComparisonContext,0);
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
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 93;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.EQUALS:
            this.state = 88;
            this.match(AgiilQueryParser.EQUALS);
            break;
        case AgiilQueryParser.NOTEQUALS:
            this.state = 89;
            this.match(AgiilQueryParser.NOTEQUALS);
            break;
        case AgiilQueryParser.TILDE:
            this.state = 90;
            this.match(AgiilQueryParser.TILDE);
            break;
        case AgiilQueryParser.NAME:
            this.state = 91;
            this.match(AgiilQueryParser.NAME);
            break;
        case AgiilQueryParser.GREATERTHAN:
        case AgiilQueryParser.LESSTHAN:
        case AgiilQueryParser.GREATERTHANOREQUAL:
        case AgiilQueryParser.LESSTHANOREQUAL:
            this.state = 92;
            this.comparison();
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

function ComparisonContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = AgiilQueryParser.RULE_comparison;
    return this;
}

ComparisonContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ComparisonContext.prototype.constructor = ComparisonContext;

ComparisonContext.prototype.GREATERTHAN = function() {
    return this.getToken(AgiilQueryParser.GREATERTHAN, 0);
};

ComparisonContext.prototype.LESSTHAN = function() {
    return this.getToken(AgiilQueryParser.LESSTHAN, 0);
};

ComparisonContext.prototype.GREATERTHANOREQUAL = function() {
    return this.getToken(AgiilQueryParser.GREATERTHANOREQUAL, 0);
};

ComparisonContext.prototype.LESSTHANOREQUAL = function() {
    return this.getToken(AgiilQueryParser.LESSTHANOREQUAL, 0);
};

ComparisonContext.prototype.accept = function(visitor) {
    if ( visitor instanceof AgiilQueryVisitor ) {
        return visitor.visitComparison(this);
    } else {
        return visitor.visitChildren(this);
    }
};




AgiilQueryParser.ComparisonContext = ComparisonContext;

AgiilQueryParser.prototype.comparison = function() {

    var localctx = new ComparisonContext(this, this._ctx, this.state);
    this.enterRule(localctx, 22, AgiilQueryParser.RULE_comparison);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 95;
        _la = this._input.LA(1);
        if(!((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.GREATERTHAN) | (1 << AgiilQueryParser.LESSTHAN) | (1 << AgiilQueryParser.GREATERTHANOREQUAL) | (1 << AgiilQueryParser.LESSTHANOREQUAL))) !== 0))) {
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
    this.enterRule(localctx, 24, AgiilQueryParser.RULE_value);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 99;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,10,this._ctx);
        switch(la_) {
        case 1:
            this.state = 97;
            this.constantvalue();
            break;

        case 2:
            this.state = 98;
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
    this.enterRule(localctx, 26, AgiilQueryParser.RULE_constantvalue);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 113;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case AgiilQueryParser.NAME:
            this.state = 101;
            this.match(AgiilQueryParser.NAME);
            break;
        case AgiilQueryParser.NOT:
            this.state = 102;
            this.match(AgiilQueryParser.NOT);
            break;
        case AgiilQueryParser.AND:
            this.state = 103;
            this.match(AgiilQueryParser.AND);
            break;
        case AgiilQueryParser.OR:
            this.state = 104;
            this.match(AgiilQueryParser.OR);
            break;
        case AgiilQueryParser.WORD:
            this.state = 106; 
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            do {
                this.state = 105;
                this.match(AgiilQueryParser.WORD);
                this.state = 108; 
                this._errHandler.sync(this);
                _la = this._input.LA(1);
            } while(_la===AgiilQueryParser.WORD);
            break;
        case AgiilQueryParser.DESCENDING:
            this.state = 110;
            this.match(AgiilQueryParser.DESCENDING);
            break;
        case AgiilQueryParser.ASCENDING:
            this.state = 111;
            this.match(AgiilQueryParser.ASCENDING);
            break;
        case AgiilQueryParser.QUOTEDVALUE:
            this.state = 112;
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
    this.enterRule(localctx, 28, AgiilQueryParser.RULE_functioninvocation);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 115;
        this.match(AgiilQueryParser.NAME);
        this.state = 116;
        this.match(AgiilQueryParser.OPENPAREN);
        this.state = 117;
        this.functionparameters();
        this.state = 118;
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
    this.enterRule(localctx, 30, AgiilQueryParser.RULE_functionparameters);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 128;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << AgiilQueryParser.NOT) | (1 << AgiilQueryParser.AND) | (1 << AgiilQueryParser.OR) | (1 << AgiilQueryParser.DESCENDING) | (1 << AgiilQueryParser.ASCENDING) | (1 << AgiilQueryParser.NAME) | (1 << AgiilQueryParser.WORD) | (1 << AgiilQueryParser.QUOTEDVALUE))) !== 0)) {
            this.state = 120;
            this.value();
            this.state = 125;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            while(_la===AgiilQueryParser.COMMA) {
                this.state = 121;
                this.match(AgiilQueryParser.COMMA);
                this.state = 122;
                this.value();
                this.state = 127;
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
    this.enterRule(localctx, 32, AgiilQueryParser.RULE_orders);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 130;
        this.match(AgiilQueryParser.ORDERBY);
        this.state = 131;
        this.orderelement();
        this.state = 136;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===AgiilQueryParser.COMMA) {
            this.state = 132;
            this.match(AgiilQueryParser.COMMA);
            this.state = 133;
            this.orderelement();
            this.state = 138;
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
    this.enterRule(localctx, 34, AgiilQueryParser.RULE_orderelement);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 141;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,16,this._ctx);
        switch(la_) {
        case 1:
            this.state = 139;
            this.match(AgiilQueryParser.NAME);
            break;

        case 2:
            this.state = 140;
            this.functioninvocation();
            break;

        }
        this.state = 144;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===AgiilQueryParser.DESCENDING || _la===AgiilQueryParser.ASCENDING) {
            this.state = 143;
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
