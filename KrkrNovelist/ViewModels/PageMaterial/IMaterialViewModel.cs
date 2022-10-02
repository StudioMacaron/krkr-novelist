using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace KrkrNovelist.ViewModels.PageMaterial
{
    public interface IMaterialViewModel<T>
    {
        /// <summary>
        /// 素材のデータ
        /// </summary>
        ReactiveProperty<T> Data { get; set; }
    }
}
