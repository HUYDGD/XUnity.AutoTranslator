﻿using System.Collections.Generic;
using System.Text;
using XUnity.AutoTranslator.Plugin.Core.Configuration;
using XUnity.AutoTranslator.Plugin.Core.Extensions;
using XUnity.AutoTranslator.Plugin.Core.Support;

namespace XUnity.AutoTranslator.Plugin.Core.Parsing
{
   internal class RegexSplittingTextParser
   {
      public RegexSplittingTextParser()
      {
      }

      public bool CanApply( object ui )
      {
         return !ComponentHelper.Instance.IsSpammingComponent( ui );
      }

      public ParserResult Parse( string input, int scope, IReadOnlyTextTranslationCache cache )
      {
         if( cache.TryGetTranslationSplitter( input, scope, out var match, out var splitter ) )
         {
            return new ParserResult( ParserResultOrigin.RegexTextParser, input, splitter.Translation, true, true, Settings.CacheRegexPatternResults, true, splitter.CompiledRegex, match );
         }

         return null;
      }
   }
}
