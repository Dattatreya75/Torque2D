//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

function FaceObjectBehavior::initialize(%this, %target, %turnSpeed, %rotationOffset)
{
    %this.target = %target;
    %this.turnSpeed = %turnSpeed;
    %this.rotationOffset = %rotationOffset;
}

//-----------------------------------------------------------------------------

function FaceObjectBehavior::onBehaviorAdd(%this)
{
    %this.schedule(200, updateFace);
}

//-----------------------------------------------------------------------------

function FaceObjectBehavior::updateFace(%this)
{
    if (!isObject(%this.target) || !%this.owner.active)
        return;
   
    %origin = %this.owner.getPosition();
    %angle = -mRadToDeg( mAtan( getWord(%this.target.getPosition(),0)-getWord(%origin,0), getWord(%this.target.getPosition(),1)-getWord(%origin,1) ) );
    
    if ( %this.turnSpeed > 0.0 )
    {
        %this.owner.rotateTo(%angle, %this.turnSpeed);
    }
    else
    {
        %this.owner.setAngle(%angle);
    }
    
      
    %this.schedule(200, updateFace);
}
