using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigilGenerator.SigilGeneration.AltMode.Shapes {
    public abstract class StuffWithVertecies: Shape {
        protected int _floored;
        protected int _vertecies;
        protected float _innerAngle;
        public override void GenerateSelf(Random random) {
            _floored = random.Next(0,2);
            _vertecies = random.Next(3, 5);
            _innerAngle = 360 / _vertecies;
            var sizeRatio = MathF.Cos((90 - _innerAngle / 2).Deg2Rads());
            //center is alway in the end.
            if (random.NextSingle() < 0.4)
                for (int i = 0; i < _vertecies; i++) {
                    _templates.Add(new FreePlaceBuilder(_innerAngle * i + (_innerAngle * _floored)/2, sizeRatio));
                }
            if (this.GetType() != typeof(Star))
                _templates.Add(new FreePlaceBuilder(0, sizeRatio, 0));
        }
    }
}
