using LeoLib.game.model.asset;
using OpenTK.Mathematics;

namespace LeoLib
{
    public abstract class Asset
    {
        private Transform transform = null;

        private Mesh mesh = null;

        private Behavior bahavior = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Asset(Mesh mesh)
        {
            this.transform = new Transform();
            this.bahavior = new Behavior();

            this.mesh = mesh;
        }

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        public abstract void AssignTextures();

        public abstract void DeleteTextures();

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime)
        {
            bahavior.Update(deltaTime, transform);
        }

        public void Add(Action action)
        {
            bahavior.Add(new State("Start", action));
        }

        public void Add(State state)
        {
            bahavior.Add(state);
        }

        /// <summary>
        /// Check() - Checks the behavior states of the current asset.  This <br/>
        /// function allows the asset to traverse from one state to another.  <br/>
        /// The "context" object contains the current context of the render <br/>
        /// loop.
        /// </summary>
        /// 
        /// <param name="context"></param>
        public void Check(EventContext context)
        {
            bahavior.Check(context);
        }

        /// <summary>
        /// Construct() - Builds the mesh that is associated with the asset.  <br/>
        /// This is done by setting up the vbo, vao and possible ebo.  <br/>
        /// This also includes the binding and unbinding of all buffers.
        /// </summary>
        public void Construct()
        {
            mesh.Contruct();
        }

        public void Render()
        {
            AssignTextures();
            mesh.Render();
        }

        public void OnUnLoad()
        {
            mesh.OnUnLoad();
            DeleteTextures();
        }

        public Matrix4 GetModel()
        {
            return (transform.GetModel());
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// BindVao() - Binds the VAO of the mesh.  This is used during the <br/>
        /// execution of the shader that is associated with the asset.  <br/>
        /// Only one shader can be associated with a asset.
        /// </summary>
        public void BindVao()
        {
            mesh.BindVao();
        }

        /*private void Rotate(float x, float y, float z)
        {
            transform.Rotate(x, y, z);
        }

        public void Translate(float x, float y, float z)
        {
            transform.Translate(x, y, z);
        }

        private void Scale(float x, float y, float z)
        {
            transform.Scale(x, y, z);
        }*/
    }
}
